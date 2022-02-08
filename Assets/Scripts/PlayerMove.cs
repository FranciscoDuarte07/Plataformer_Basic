using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float runSpeed = 2;
    [SerializeField] float jumpSpeed = 3;
    [SerializeField] float doubleJumpSpeed = 3.5f;
    public bool canDoubleJump;
    [SerializeField] bool jumping = false;
    [SerializeField] float fallMultiplier = 0.5f;
    [SerializeField] float lowJumpMultiplier = 1f;
    Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    
    [SerializeField] GameObject dustLeft;
    [SerializeField] GameObject dustRight;
    
    [SerializeField] float dashCooldown;
    [SerializeField] float dashForce = 30;
    [SerializeField] GameObject dashParticle;

    [SerializeField] bool isTouchingFront = false;
    bool wallSliding;
    [SerializeField] float wallSlidingSpeed = 0.75f;
    bool isTouchingLeft;
    bool isTouchingRight;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dashCooldown -= Time.deltaTime;

        if (Input.GetKey("space") && wallSliding == false)
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }
            else if (Input.GetKeyDown("space"))
            {
                if (canDoubleJump)
                {
                    animator.SetBool("DoubleJump", true);
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, doubleJumpSpeed);
                    canDoubleJump = false;
                }
            }
        }


        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        if (rigidBody.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rigidBody.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        if (isTouchingFront == true && CheckGround.isGrounded == false)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            animator.Play("Wall");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Clamp(rigidBody.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }



    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right") && isTouchingRight == false)
        {
            rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
            if (Input.GetKey("left shift") && dashCooldown <= 0)
            {
                Dash();
            }

        }
        else
        if (Input.GetKey("left shift") && dashCooldown<=0)
        {
            Dash();
        }

        else
        if (Input.GetKey("a") || Input.GetKey("left") && isTouchingLeft == false)
        {
            rigidBody.velocity = new Vector2(-runSpeed, rigidBody.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {
                dustRight.SetActive(true);
                dustLeft.SetActive(false);
            }
            if (Input.GetKey("left shift") && dashCooldown <= 0)
            {
                Dash();
            }
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (jumping)
        {
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rigidBody.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    public void Dash()
    {
        GameObject dashObject;

        dashObject = Instantiate(dashParticle, transform.position, transform.rotation);

        if (spriteRenderer.flipX == true)
        {
            rigidBody.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        else
        {
            rigidBody.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
        dashCooldown = 2;

        Destroy(dashObject, 1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            isTouchingFront = true;
            isTouchingRight = true;
        }
        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            isTouchingFront = true;
            isTouchingLeft = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFront = false;
        isTouchingLeft = false;
        isTouchingRight = false;
    }
}
