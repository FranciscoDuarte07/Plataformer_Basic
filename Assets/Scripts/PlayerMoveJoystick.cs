using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    [SerializeField] Joystick joystick;

    [SerializeField] float runSpeedHorizontal = 2;
    [SerializeField] float runSpeed = 1.25f;
    [SerializeField] float jumpSpeed = 3;
    [SerializeField] float doubleJumpSpeed = 3.5f;
    public bool canDoubleJump;
    Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else
       if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
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
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        else
        {
            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
        }
    }
}
