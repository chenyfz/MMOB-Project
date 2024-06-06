using UnityEngine;

public class DualTiltTracker : MonoBehaviour
{
    public GameObject Indicator;
    public GameObject Border;
    // Start is called before the first frame update
    float minRange, maxRange;
    void Start()
    {
        var rangeOffset = Border.GetComponent<RectTransform>().rect.size.x / 2 - Indicator.GetComponent<RectTransform>().rect.size.x;
        minRange = Border.transform.position.x - rangeOffset;
        maxRange = Border.transform.position.x + rangeOffset;
    }

    // Update is called once per frame
    void Update()
    {
        var xMove = GameMaster.Instance.player.GetComponent<PlayerController>().xMove;
        var axis = xMove.action.ReadValue<float>();

        // full left = -1, middle = 0, full right = 1
        var x = Mathf.Lerp(minRange, maxRange, (axis + 1) / 2);
        Indicator.transform.position = new Vector3(x, Indicator.transform.position.y, Indicator.transform.position.z);
    }
}
