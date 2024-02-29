using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        
    }

    public Rigidbody2D body;
    public float powerJump;
    public float moveSpeed;
    int maxJump = 3;
    int currentJump = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentVelocity += new Vector2(moveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentVelocity += new Vector2(-moveSpeed, 0);
        }

        body.velocity = currentVelocity;

        if (currentJump < maxJump)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(new Vector2(0, 1) * powerJump);
                currentJump++;
            }
        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            currentJump = 0;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
