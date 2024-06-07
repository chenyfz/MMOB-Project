using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Background1;
    public GameObject Background2;
    public float distance;
    // Start is called before the first frame update

    private GameObject CurrentBackground;
    private int loopAmount = 1;
    void Start()
    {
        CurrentBackground = Background1;
    }

    public void Reset()
    {
        Background1.transform.position = new Vector3(0, 0, 0);
        Background2.transform.position = new Vector3(0, distance, 0);
        CurrentBackground = Background1;
    }

    // Move the down background up if we are out of bounds
    void Update()
    {
        var player = GameMaster.Instance.player;
        if (player.transform.position.y >= (CurrentBackground.transform.position.y + distance))
        {
            loopAmount++;
            var newPosY = loopAmount * distance;
            if (CurrentBackground == Background1)
            {
                CurrentBackground.transform.position = new Vector3(0, newPosY, 0);
                CurrentBackground = Background2;
            }
            else
            {
                CurrentBackground.transform.position = new Vector3(0, newPosY, 0);
                CurrentBackground = Background1;
            }
        }
    }
}
