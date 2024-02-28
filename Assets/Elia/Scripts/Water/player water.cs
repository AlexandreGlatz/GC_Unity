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
        float Spritesize = GetComponent<SpriteRenderer>().bounds.size.y;
        float camheight = Camera.main.orthographicSize;
        spriteRenderer.flipY = false;   

        yMin = -camheight + Spritesize/2;
        yMax = camheight - Spritesize/2;
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(1*speed,0);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-1*speed,0);
            spriteRenderer.flipY = true;
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

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
