using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public CameraFollow cam;
    public mobBehavior mobBehavior;
    public GameObject captureHelp;
    public LoadingScreen loadingScene;

    public SpriteRenderer seedBag;
    public float powerJump;
    public float moveSpeed;
    private bool canWalk = true;
    private bool canJump = true;
    private bool canCapture = false;

    //Start is called before the first frame update
    void Start()
    {
        seedBag.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Destroy(GameObject.Find("PlayerUI"));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);

        //goes back to idle animation
        animator.ResetTrigger("isWalking");
        animator.ResetTrigger("isFalling");
        animator.ResetTrigger("isJumping");

        //walk right
        if (Input.GetKey(KeyCode.RightArrow) && canWalk)
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            spriteRenderer.flipX = false;
        }

        //walk left
        if (Input.GetKey(KeyCode.LeftArrow) && canWalk)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
            animator.SetTrigger("isWalking"); //animation
            spriteRenderer.flipX = true;
        }

        body.velocity = currentVelocity;

        //jump

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            animator.SetTrigger("isJumping");
            body.AddForce(new Vector2(0, 1) * powerJump);
            canJump = false;
        }

        //animate fall
        if (body.velocity.y < 0)
        {
            animator.SetTrigger("isFalling");
        }

        if (canCapture)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(catchMob());
            }
        }

    }

    private IEnumerator catchMob()
    {
        captureHelp.SetActive(false);
        seedBag.enabled = true;
        if (mobBehavior.walkDir)
        {
            animator.SetTrigger("isCapturing");
        }
        else
        {
            animator.SetTrigger("isCapturingLeft");
        }
        canWalk = false;
        canJump = false;
        seedBag.enabled = true;
        yield return new WaitForSeconds(0.2f);
        mobBehavior.isCaptured = true;
        yield return new WaitForSeconds(0.5f);
        loadingScene.LoadScene(1); //Goes back to farm
    }

    public void getHit(int mobStrength)
    {
        body.AddForce(new Vector2(1, 1) * mobStrength);
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lowCam")
        {
            cam.lowerCam = true;
        }

        if (collision.gameObject.tag == "captureZone" && mobBehavior.isDead)
        {
            captureHelp.SetActive(true);
            canCapture = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "lowCam")
        {
            cam.lowerCam = false;
        }

        if (collision.gameObject.tag == "captureZone" && mobBehavior.isDead)
        {
            captureHelp.SetActive(false);
            canCapture = false;
        }
    }

}