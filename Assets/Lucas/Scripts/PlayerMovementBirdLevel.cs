using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerMovementBirdLevel : MonoBehaviour
{
    //Singleton
    public static PlayerMovementBirdLevel instance;
    public Rigidbody2D body;
    public Animator animator;
    public float powerJump;

    public float x;
    public float y;
    public float z;
    private SpriteRenderer spriteRenderer;
    private bool canJump = true;
    private bool canCapture = false;
    public SpriteRenderer seedBag;

    public GameObject captureHelp;
    public bool isJump;
    public LoadingScreen loadingScene;


    [Header("Currency")]
    public int currency = 0;
    public TextMeshProUGUI MoneyUI;

    Camera camera;


    public void IncreaseCurrency(int amout)
    {
        currency += amout;
        MoneyUI.text = "Money : " + currency;
    }

    public IEnumerator JumpTime()
    {
        isJump = true;
        yield return new WaitForSeconds((float)0.6);
        isJump = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
        camera = Camera.main;


        seedBag.enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();


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
        if (isJump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                body.AddForce(new Vector2(0, 1) * powerJump);
                canJump = false;
                StartCoroutine(JumpTime());
            }
        }

        y = body.position.y;
        z = PlayerPrefs.GetFloat("z");
        x = body.position.x;

        if (y <= (float)-7.2)
        {
            Vector3 LoadPosition = new Vector3(0, -2, 0);
            transform.position = LoadPosition;
        }

        if (x >= (float)10.1)
        {
            Vector3 LoadPosition = new Vector3((float)-10, gameObject.transform.position.y, 0);
            transform.position = LoadPosition;
        }

        if (x <= (float)-10.1)
        {
            Vector3 LoadPosition = new Vector3((float)10, gameObject.transform.position.y, 0);
            transform.position = LoadPosition;
        }

        if (camera.transform.position.y + camera.orthographicSize < gameObject.transform.position.y && gameObject.transform.position.y < 58)
        {
            Vector3 LoadPosition = new Vector3(0, camera.transform.position.y + 12, -10);
            camera.transform.position = LoadPosition;
        }


        if (camera.transform.position.y - camera.orthographicSize > gameObject.transform.position.y)
        {
            Vector3 LoadPosition = new Vector3(0, camera.transform.position.y - 12, -10);
            camera.transform.position = LoadPosition;
        }

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
        print("aa");
        captureHelp.SetActive(false);
        seedBag.enabled = true;
        animator.SetTrigger("isCapturing");
        yield return new WaitForSeconds(0.2f);
        yield return new WaitForSeconds(0.5f);
        loadingScene.LoadScene(0); //Goes back to farm
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "captureZone")
        {
            captureHelp.SetActive(true);
            canCapture = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "captureZone")
        {
            captureHelp.SetActive(false);
            canCapture = false;
        }
    }

}
