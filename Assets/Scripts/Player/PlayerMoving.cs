using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    // Use for reference to the player
    private Rigidbody2D body;

    // Use for reference to the animation
    private Animator animator;

    // Use to tell when the player is on the ground
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    // To adjust the speed of the movement
    [SerializeField] private float speed;

    [SerializeField] private AudioClip jumpSound;

    // Run when the game starts
    private void Awake()
    {
        // To get the player
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Run when there is an update for example clicking a keys
    private void Update()
    {

        //Use when detecting left and right movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // To flip the image when moving right or left
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1,1);

        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", isGrounded());

        // To make the player jump
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded())
            Jump();

        // To make the player move to left or right
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        animator.SetTrigger("jump");
        SoundManager.instance.PlaySound(jumpSound);
    }
    
    private bool isGrounded()
    {
        RaycastHit2D reycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return reycastHit.collider != null;
    }
}
