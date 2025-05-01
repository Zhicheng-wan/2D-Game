using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float movement;
    public float speed = 5f;
    public bool facingRight = true;
    public float jumpForce = 10f;
    public bool isGrounded = true;
         
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal"); 
        // Set the animator's speed parameter based on the player's movement
        animator.SetFloat("Speed", Mathf.Abs(movement));

        // Check if the player is moving left or right
        if (movement > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement < 0 && facingRight)
        {
            Flip();
        }

        // Check if the player is grounded and the jump button is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Call the Jump function
            Jump();
            isGrounded = false; // Set isGrounded to false after jumping
            animator.SetBool("Jump",true); // Trigger the jump animation
        }

        // if pressing the j key, play the attack animation
        if (Input.GetKeyDown(KeyCode.J))
        {   
            animator.SetTrigger("Attack");
        }
    }
    // Flip the player sprite
    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Move the player with speed

        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);
    }
    // Jump the player
    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    // OnCollisionEnter2D is called when the collider attached to the object collides with another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true when colliding with the ground
            animator.SetBool("Jump", false); // Reset the jump animation
        }
    }
}
