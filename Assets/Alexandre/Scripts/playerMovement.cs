using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public CameraFollow cam;


    public float powerJump;
    public float moveSpeed;
    int maxJump = 1;
    int currentJump = 0;

    //Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        animator.ResetTrigger("isWalking");
        animator.ResetTrigger("isFalling");
        animator.ResetTrigger("isJumping");

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            animator.SetTrigger("isWalking");
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
            animator.SetTrigger("isWalking");
            spriteRenderer.flipX = true;
        }

        body.velocity = currentVelocity;

        if (currentJump < maxJump)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetTrigger("isJumping");
                body.AddForce(new Vector2(0, 1) * powerJump);
                currentJump++;
            }
        }

        if (body.velocity.y <0)
        {
            animator.SetTrigger("isFalling");
        }

    }

    public void getHit(int mobStrength)
    {
        body.AddForce(new Vector2(1, 1) * mobStrength);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            currentJump = 0;
        }

        if (collision.gameObject.tag == "lowCam")
        {
            cam.lowerCam = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "lowCam")
        {
            cam.lowerCam = false;
        }
    }

}
