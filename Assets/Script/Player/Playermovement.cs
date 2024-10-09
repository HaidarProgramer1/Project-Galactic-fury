using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;  // Define the jump force variable
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask platformLayer;  // Layer for platforms
    [SerializeField] private AudioClip jumpSound;
    private Rigidbody2D body;
    private Vector3 localScale;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;  // Declare horizontalInput as a class member

    private void Awake()
    {
        // Grab references for Rigidbody2D, Animator, and BoxCollider2D from the object
        body = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");  // Update horizontalInput here
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Flip player when moving left or right
        if (horizontalInput > 0.01f)
            transform.localScale = localScale;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        
        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
            Jump();

        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        // Adjustable jump height
        if(Input.GetKeyUp(KeyCode.W) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        
        if(onWall())
        {
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

    }
    
     
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);  // Use jumpForce here
        SoundManager.instance.PlaySound(jumpSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player landed on a platform
        if ((platformLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            // Ensure the player is upright
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
    }

    private bool isGrounded()
    {
        // Perform BoxCast downward to check if the player is grounded or standing on a platform
        RaycastHit2D raycastHitGround = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer | platformLayer);
        return raycastHitGround.collider != null;
    }

    private bool onWall()
    {
        // Perform BoxCast horizontally to check if the player is touching a wall
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();  // Use horizontalInput here
    }
}
