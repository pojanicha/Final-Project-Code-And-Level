using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 6.5f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool doubleJump;
    [SerializeField] private float doubleJumpForce = 6.5f;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }


        if (Input.GetButtonDown("Jump"))
        {
           if (IsGrounded() || doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJump ? doubleJumpForce : jumpForce);

                doubleJump = !doubleJump;
            }
        }


        Flip();

    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        { 
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;


        }
    
    }
    


  
}
