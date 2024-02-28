using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarBehavior : MonoBehaviour
{

    public Rigidbody2D boarBody;
    public float moveSpeed;
    public bool isCharging;
    public bool walkLeft = true;
    public bool walkRight = false;


    // Start is called before the first frame update
    void Start()
    {
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Idle()
    {
        Vector2 currentVelocity = new Vector2(0, boarBody.velocity.y);

        if (walkLeft)
        {
            currentVelocity += new Vector2(-moveSpeed, 0);

        } else if (walkRight)

        {
            currentVelocity += new Vector2(-moveSpeed, 0);
        }
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
