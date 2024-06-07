using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{


    [Header("References")]
    public SpriteRenderer spriteRenderer;


    [Header("Ground Settings")]
    [SerializeField][Tooltip("Downward raycast size")] private float groundExtend = 0.10f;
    [SerializeField] GameObject groundOffset = null;
    // Ground position (assumed as the middle, see game object)
    Vector2 GroundPosition => groundOffset.transform.position;
    public float groundWidth = 0.45f;


    [Header("Layer Masks")]
    [SerializeField][Tooltip("Which layers are read as the ground")] private LayerMask groundLayer;



    [Header("Movement")]
    [Range(1f, 15.0f)][Tooltip("Maximum jump height")] public float jumpHeight = 9.0f;
    [Range(1f, 15.0f)][Tooltip("X speed")] public float moveSpeed;
    private float defaultGravityScale;


    [Header("State")]
    public bool currentlyJumping;
    public bool onGround;
    public float gravMultiplier;

    [Header("Input")]
    [SerializeField] public InputActionReference xMove;


    // Private variables
    private Vector2 desiredVelocity;
    private Rigidbody2D rb;
    private BoxCollider2D hitbox;
    private Color defaultColor = Color.white;
    private Color damageColor = Color.red;
    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
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
        desiredVelocity.x = xMoveAmount * Mathf.Max(moveSpeed, 0f);
    }

    private void FixedUpdate()
    {
        var velocity = rb.velocity;
        velocity.x = desiredVelocity.x;
        rb.velocity = velocity;
        XScrollUpdate();

        // Going up so we can pass through everything
        if (rb.velocity.y > 0.0f)
        {
            onGround = false;
        }
        else
        {
            var sizeConsideration = GetSizeConsideration();
            //Determine if the player is stood on objects on the ground layer, using a pair of raycasts
            var rightHit = Physics2D.Raycast(GroundPosition + sizeConsideration, Vector2.down, groundExtend, groundLayer);
            var leftHit = Physics2D.Raycast(GroundPosition - sizeConsideration, Vector2.down, groundExtend, groundLayer);
            onGround = leftHit || rightHit;
            if (leftHit && leftHit.collider.GetComponent<Platform>() != null)
                leftHit.collider.GetComponent<Platform>().OnPlayerLand();
            if (rightHit && rightHit.collider.GetComponent<Platform>() != null)
                rightHit.collider.GetComponent<Platform>().OnPlayerLand();
        }


        // Auto jump if the player is on the ground
        if (onGround)
        {
            velocity.y = 0;
            Jump();
        }
    }

    void Jump()
    {
        GameMaster.Instance.PlaySFX("jump");
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }

    Vector2 GetSizeConsideration()
    {
        return new Vector2((hitbox.size.x / 2) * groundWidth, 0.0f);
    }


    void XScrollUpdate()
    {
        if (hitbox.bounds.max.x - hitbox.size.x / 2 > GameMaster.Instance.bottomRight.transform.position.x)
        {
            // Wrap the player around to the other side of the screen
            transform.position = new Vector3(GameMaster.Instance.topLeft.transform.position.x, transform.position.y, transform.position.z);
        }

        if (hitbox.bounds.min.x + hitbox.size.x / 2 < GameMaster.Instance.topLeft.transform.position.x)
        {
            // Wrap the player around to the other side of the screen
            transform.position = new Vector3(GameMaster.Instance.bottomRight.transform.position.x, transform.position.y, transform.position.z);

        }
    }

    public void Die()
    {
        Debug.Log("We died L");
        GameMaster.Instance.Reset();
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

        if (hitbox != null && hitbox.enabled)
        {
            var sizeConsideration = GetSizeConsideration();
            Gizmos.DrawLine(GroundPosition + sizeConsideration, (GroundPosition + sizeConsideration) + Vector2.down * groundExtend);
            Gizmos.DrawLine(GroundPosition - sizeConsideration, (GroundPosition - sizeConsideration) + Vector2.down * groundExtend);

            // Draw hitbox
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(hitbox.bounds.center, hitbox.bounds.size);
        }

    }

}
