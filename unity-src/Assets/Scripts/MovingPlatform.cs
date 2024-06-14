using UnityEngine;

public class MovingPlatform : Platform
{
    public bool startLeft = true;
    public float speed = 1.0f;

    private BoxCollider2D hitbox;
    private bool movingLeft;
    public void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        movingLeft = startLeft;
    }

    public void Update()
    {
        BoundsUpdate();

        if (movingLeft)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    void BoundsUpdate()
    {
        if (hitbox.bounds.max.x > GameMaster.Instance.bottomRight.transform.position.x)
        {
            movingLeft = true;
        }

        if (hitbox.bounds.min.x < GameMaster.Instance.topLeft.transform.position.x)
        {
            movingLeft = false;
        }
    }
}
