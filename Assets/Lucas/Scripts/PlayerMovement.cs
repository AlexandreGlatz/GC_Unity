using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public Animator animator;
    public float powerJump;

    public float x;
    public float y;
    public float z;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        bool isRunning = false;
        spriteRenderer.flipX = false;

        if (Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(5, 0);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-5, 0);
            isRunning = true;
            spriteRenderer.flipX = true;
        }

        animator.SetBool("isRunning", isRunning);

        body.velocity = currentVelocity;


        if (Input.GetKeyDown(KeyCode.S))
        {
            body.AddForce(new Vector2(0, -1) * powerJump);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, 1) * powerJump);
        }

        x = PlayerPrefs.GetFloat("x");
        y = body.position.y;
        z = PlayerPrefs.GetFloat("z");
        print(y);

        if (y <= -13)
        {
            Vector3 LoadPosition = new Vector3(-7, -1, 0);
            transform.position = LoadPosition;
        }

        
    }

}
