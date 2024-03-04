using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_water : MonoBehaviour
{

    public Rigidbody2D body;
    public float speed;
    public float powerjump;
    private float yMin, yMax;
    public float gravity;
    private SpriteRenderer spriteRenderer;
    private bool rotate;




    


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();    
        rotate = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        float Spritesize = GetComponent<SpriteRenderer>().bounds.size.y;
        float camheight = Camera.main.orthographicSize;

        yMin = -camheight + Spritesize/2;
        yMax = camheight - Spritesize/2;
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
           currentVelocity += new Vector2(1*speed,0);
            if (rotate)
            {
                transform.Rotate(transform.rotation.x+180, 0, 0);
                rotate = false;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-1*speed,0);
            if (rotate == false)
            {
                transform.Rotate(transform.rotation.x-180, 0, 0);
                rotate = true;
            }

        }


        body.velocity = currentVelocity;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            body.velocity = new Vector2(currentVelocity.x,0);
            body.AddForce(new Vector2(0, 1) * powerjump);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            body.velocity = new Vector2(currentVelocity.x, 0);
            body.AddForce(new Vector2(0, -1)*gravity);
        }

        if (body.position.y < yMin) { transform.position = new Vector2(body.position.x,yMin); }
        if (body.position.y > yMax) { transform.position = new Vector2(body.position.x, yMax); }
    }

    void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jelly_fish")
        {
            print("a");
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
