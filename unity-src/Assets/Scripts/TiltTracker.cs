using UnityEngine;
using UnityEngine.UI;

public class TiltTracker : MonoBehaviour
{
    public bool left;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var xMove = GameMaster.Instance.player.GetComponent<PlayerController>().xMove;
        var axis = xMove.action.ReadValue<float>();
        float sign = left ? -1.0f : 1.0f;
        if (Mathf.Sign(sign) != Mathf.Sign(axis))
        {
            slider.value = 0.0f;
            return;
        }
        slider.value = Mathf.Clamp(axis * sign, 0.0f, 1.0f);
    }
}
