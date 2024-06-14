using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class GyroInputController : MonoBehaviour
{
    private InputDevice virtualGamepad;
    
    [DllImport("__Internal")]
    private static extern void StartListeningGyro();
    
    [DllImport("__Internal")]
    private static extern int GetGyroMilliGamma();

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        virtualGamepad = InputSystem.AddDevice<Gamepad>();
        StartListeningGyro();
#endif
    }

    void Update()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // -1: -45 deg, 1: 45 deg
        var stickInputFromGamma = GetGyroMilliGamma() / 45000f;
        if (stickInputFromGamma > 1) stickInputFromGamma = 1;
        if (stickInputFromGamma < -1) stickInputFromGamma = -1;
        
        InputSystem.QueueStateEvent(virtualGamepad, new GamepadState
        {
            leftStick = new Vector2(stickInputFromGamma, 0)
        });
#endif
    }
}
