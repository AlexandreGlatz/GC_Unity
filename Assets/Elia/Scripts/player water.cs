using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_water : MonoBehaviour
{

    public Rigidbody2D body;
    public float speed;
    public float powerjump;





    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(1*speed,0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-1*speed,0);
        }


        if (Input.GetKey(KeyCode.Z))
        {
            currentVelocity += new Vector2(0, 1 * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentVelocity += new Vector2(0, -1 * speed);
        }

        body.velocity = currentVelocity;
    }

    void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
