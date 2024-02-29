using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobBehavior : MonoBehaviour
{

    public Rigidbody2D boarBody;
    public float moveSpeed;
    public bool isCharging;
    public bool walkLeft = true;
    public bool walkRight = false;

    public bool playerSeen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
    }

    private void Idle()
    {
        Vector2 currentVelocity = new Vector2(0, boarBody.velocity.y);

        if (walkLeft)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);

        } else if (walkRight)

        {
            currentVelocity += new Vector2(moveSpeed, 0);
        }

        boarBody.velocity = currentVelocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            walkLeft = !walkLeft;
            walkRight = !walkRight;
        } 
    }

}
