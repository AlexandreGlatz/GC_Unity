using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerwater : MonoBehaviour
{

    public Animator animator;
    public GameObject Fish;
    public Rigidbody2D body;
    public float speed;
    public float powerjump;
    private float yMin, yMax;
    public float gravity;
    private SpriteRenderer spriteRenderer;
    private bool rotate;
    public bool isdead;
    public bool fish_stun;
    public bool lighton;


    public bool canCapture;
    public SpriteRenderer seedBag;

    public GameObject captureHelp;

    public LoadingScreen loadingScene;




    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();    
        rotate = false;
        isdead = false;

        seedBag.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        canCapture = false;
        lighton = true;
    }


    // Update is called once per frame
    void Update()
    {
        fish_stun = GameObject.Find("abyss fish").GetComponent<AnglerFish>().is_stun;


        if (!lighton)
        {
            loadingScene.LoadScene(1); //Goes back to farm
        }

        if ( !isdead)
        {
            Vector2 currentVelocity = new Vector2(0, body.velocity.y);
            float Spritesize = GetComponent<SpriteRenderer>().bounds.size.y;
            float camheight = Camera.main.orthographicSize;

            yMin = -camheight + Spritesize / 2;
            yMax = camheight - Spritesize / 2;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                currentVelocity += new Vector2(1 * speed, 0);
                if (rotate)
                {
                    transform.Rotate(transform.rotation.x + 180, 0, 0);
                    rotate = false;
                }

            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
            {
                currentVelocity += new Vector2(-1 * speed, 0);
                if (rotate == false)
                {
                    transform.Rotate(transform.rotation.x - 180, 0, 0);
                    rotate = true;
                }

            }


            body.velocity = currentVelocity;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
            {
                body.velocity = new Vector2(currentVelocity.x, 0);
                body.AddForce(new Vector2(0, 1) * powerjump);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                body.velocity = new Vector2(currentVelocity.x, 0);
                body.AddForce(new Vector2(0, -1) * gravity);
            }


        }
        if (body.position.y < yMin) { transform.position = new Vector2(body.position.x, yMin); }
        if (body.position.y > yMax) { transform.position = new Vector2(body.position.x, yMax); }

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
        animator.SetTrigger("isCapturing");
        Fish.GetComponent<AnglerFish>().isCaptured = true;
        yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(0.5f);
        loadingScene.LoadScene(1); //Goes back to farm
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fish" && fish_stun)
        {
            captureHelp.SetActive(true);
            canCapture = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fish")
        {
            captureHelp.SetActive(false);
            canCapture = false;
        }
    }


    public void Damage()
    {
        speed  = 1;
        StartCoroutine(isStunned());
    }

    public IEnumerator isStunned()
    {

        yield return new WaitForSeconds((float)0.5);
        speed = 5;
    }



    public void Contactwithfish()
    {
        
        if (!fish_stun)
        {
            isdead = true;
            body.velocity = new Vector3(0, body.velocity.y, 0);
        }

    }

    
}
