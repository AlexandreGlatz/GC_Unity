using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Rigidbody2D body;
    public float speed;
    public float powerjump;
    public int  maxjump;
    private int jump;




    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);

        if (Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(1*speed,0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-1*speed,0);
        }

        body.velocity = currentVelocity;

        
        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            body.AddForce(new Vector2(0, 1) * powerjump);
            jump -= 1;
        }

    }

    void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = maxjump;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
