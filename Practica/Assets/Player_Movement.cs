using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Inventory inventory;
    public Movement movement;
    float horizontalMove = 0f;
    public float runSpeed = 5f;
    bool jump = false;
    bool crouch = false;
    bool isFalling = false;
    bool isClimbing = false;
    bool isGrabing = false;
    public Animator animator;
    int currentWeapon = 0;
    public Rigidbody2D rb;
    public AudioSource grabSound;

    public bool canDash;
    public bool dash;
    public float dashTime;
    float dashSpeed = 30f;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(9, 11, true);
        canDash = true;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        DashSkill();

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }

        if (rb.velocity.y < -0.1)
        {
            isFalling = true;
            animator.SetBool("isFalling", isFalling);
            animator.SetBool("isJumping", false);
        }
        else
        {
            isFalling = false;
            animator.SetBool("isFalling", isFalling);
        }
    }

    private void DashSkill()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            dashTime += 1 * Time.deltaTime;

            if (dashTime < 0.20f)
            {
                dash = true;
                animator.SetBool("isDashing", dash);
                transform.Translate(Vector3.right * dashSpeed * Time.fixedDeltaTime);
                Physics2D.IgnoreLayerCollision(9, 12, true);
                Invoke("SetCanDashBack", 3);
            } else
            {
                dash = false;
                animator.SetBool("isDashing", dash);
            }
        } else
        {
            dash = false;
            animator.SetBool("isDashing", dash);
            dashTime = 0;
        }
    }

    private void SetCanDashBack()
    {
        canDash = true;
    }

    private void ResetDash()
    {
        Physics2D.IgnoreLayerCollision(9, 12, false);
        canDash = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 24)
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true);
            animator.SetBool("isJumping", false);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                isGrabing = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 24)
        {
            
            if (Input.GetButtonDown("Grab"))
            {
                isGrabing = true;
            }

            if (Input.GetButtonUp("Grab"))
            {
                isGrabing = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 24)
        {
            isClimbing = false;
            isGrabing = false;
            animator.SetBool("isClimbing", false);
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    public bool GetCrouching()
    {
        return crouch;
    }

    public int GetCurrentWeapon()
    {
        return currentWeapon;
    }

    void FixedUpdate()
    {
        movement.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, isClimbing, isGrabing);   
        jump = false;
    }

    public void SetRunSpeed(float newRunSpeed)
    {
        this.runSpeed = newRunSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            inventory.IncreaseGold(collision.gameObject.GetComponent<Gold>().GetValue());
            Destroy(collision.gameObject);
            grabSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            inventory.IncreaseGold(collision.gameObject.GetComponent<Gold>().GetValue());
            Destroy(collision.gameObject);
            grabSound.Play();
        }
    }
}
