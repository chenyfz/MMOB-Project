using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private bool canTakeDamage = true;
    public float maxSpeed;  // = 7.5f; with boxscale 6

    public SpriteRenderer spriteRenderer;
    public GameObject topLeft;
    public GameObject bottomRight;

    private Color defaultColor = Color.white;
    private Color damageColor = Color.red;


    [Header("Collider Settings")]
    [SerializeField][Tooltip("Length of the ground-checking collider")] private float groundLength = 0.10f;
    [SerializeField] GameObject groundOffset = null;
    Vector3 GroundPosition => groundOffset.transform.position;


    [Header("Layer Masks")]
    [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;

    [SerializeField]
    private InputActionReference xMove, jump;

    private Vector2 desiredVelocity;

    private Rigidbody2D rb;

    [Header("Jumping Stats")]
    [Range(2f, 50.5f)][Tooltip("Maximum jump height")] public float jumpHeight = 9.0f;


    private float defaultGravityScale;
    public float gravMultiplier;

    public bool currentlyJumping;
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = 1.0f;
        gravMultiplier = defaultGravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTakeDamage)
        {
            Flash();
        }
        var xMoveAmount = xMove.action.ReadValue<float>();
        desiredVelocity.x = xMoveAmount * Mathf.Max(maxSpeed, 0f);
    }

    private void FixedUpdate()
    {
        var velocity = rb.velocity;
        velocity.x = desiredVelocity.x;
        rb.velocity = velocity;

        //Determine if the player is stood on objects on the ground layer, using a pair of raycasts
        onGround = Physics2D.Raycast(GroundPosition, Vector2.down, groundLength, groundLayer);

        //Keep trying to do a jump, for as long as desiredJump is true
        if (onGround)
        {
            velocity.y = 0;
            // Auto jump if the player is on the ground
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    void BoundsUpdate()
    {
        var hitbox = gameObject.GetComponent<BoxCollider2D>();


        // Move the player.

        //transform.Translate(speed * Time.deltaTime * moveVector);

        // Keep the player in bounds
        if (hitbox.bounds.max.y > topLeft.transform.position.y)
        {
        }

        if (hitbox.bounds.min.y < bottomRight.transform.position.y)
        {
        }

        if (hitbox.bounds.max.x > bottomRight.transform.position.x)
        {
        }

        if (hitbox.bounds.min.x < topLeft.transform.position.x)
        {
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canTakeDamage)
        {
            return;
        }
        StartCoroutine(InvulnTimer());
    }

    void Flash()
    {
        spriteRenderer.color = Color.Lerp(damageColor, defaultColor, Mathf.PingPong(Time.time * 3f, 1));
    }

    IEnumerator InvulnTimer()
    {
        spriteRenderer.color = damageColor;
        canTakeDamage = false;
        yield return new WaitForSeconds(0.5f);
        canTakeDamage = true;
        spriteRenderer.color = defaultColor;
    }

    // Debug gizmos
    private void OnDrawGizmos()
    {
        // Ground
        if (onGround) { Gizmos.color = Color.green; } else { Gizmos.color = Color.red; }
        Gizmos.DrawLine(GroundPosition, GroundPosition + Vector3.down * groundLength);
    }

}
