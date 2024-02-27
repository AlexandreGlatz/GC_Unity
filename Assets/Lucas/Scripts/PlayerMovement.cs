using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float powerJump; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
            
        if(Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(3, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-3, 0);
        }


        body.velocity = currentVelocity;


        if (Input.GetKeyDown(KeyCode.S))
        {
            body.AddForce(new Vector2(0, -1) * powerJump);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, 1) * powerJump);
        }



    }
}
