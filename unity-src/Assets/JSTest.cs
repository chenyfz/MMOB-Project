using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JSTest : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void Test();
    
    // Start is called before the first frame update
    void Start()
    {
        Test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JSToUnityTest()
    {
        Test();
    }
}
