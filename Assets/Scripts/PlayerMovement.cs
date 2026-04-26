using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private bool isInvicible = false;   



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


    //Respawn Code

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RespawnTrigger") && !isInvicible)
        {
            TakeDamage();

        }

        void TakeDamage()
        {
            isInvicible = true;
            HealthManager.health--;

            if (HealthManager.health <= 0)
            {
                StartCoroutine(Die());

            }

            else
            {
                Respawn();
                StartCoroutine(GetHurt());
            }
        }

        void Respawn()
        {
            transform.position = RespawnController.Instance.respawnPoint.position;
        }

        IEnumerator GetHurt()
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            yield return new WaitForSeconds(3);
            Physics2D.IgnoreLayerCollision(7, 8, false);

            isInvicible = false;
        }

        IEnumerator Die()
        {
            yield return new WaitForSeconds(0.1f);

            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }


    }



}
