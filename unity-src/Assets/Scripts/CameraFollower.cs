using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Camera cam;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        player = GameMaster.Instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(player.transform.position);
        var resolution = new Vector2(Screen.width, Screen.height);

        // Follow the player if it is above the center of the screen
        if (screenPos.y > resolution.y / 2)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }

        if (IsUnderScreen())
        {
            GameMaster.Instance.player.GetComponent<PlayerController>().Die();
        }
    }

    public bool IsUnderScreen()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(player.transform.position);
        return screenPos.y < 0;
    }
}
