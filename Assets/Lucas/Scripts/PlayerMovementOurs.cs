using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Singleton
    public static PlayerMovement instance;
    public Rigidbody2D body;
    public Animator animator;
    public float powerJump;
    public bool isWalking;

    public float x;
    public float y;
    public float z;
    private SpriteRenderer spriteRenderer;
    private bool canJump = true;
    private bool canCapture = false;
    public SpriteRenderer seedBag;

    public GameObject captureHelp;
    public LoadingScreen loadingScene;
    AudioSource walksound;

    [Header("Currency")]
    public int currency = 0;
    public TextMeshProUGUI MoneyUI;


    public void IncreaseCurrency(int amout)
    {
        currency += amout;
        MoneyUI.text = "Money : " + currency;
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
        walksound = GetComponent<AudioSource>();

        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = false;
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        bool isRunning = false;
        spriteRenderer.flipX = false;

        if (Input.GetKey(KeyCode.D))
        {
            currentVelocity += new Vector2(5, 0);
            isRunning = true;
            walksound.Play();
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentVelocity += new Vector2(-5, 0);
            isRunning = true;
            spriteRenderer.flipX = true;
            walksound.Play();
            isWalking = true;
        }
        if (isWalking == false)
        {
            walksound.Stop();
        }
        animator.SetBool("isRunning", isRunning);

        body.velocity = currentVelocity;


        if (Input.GetKeyDown(KeyCode.S))
        {
            body.AddForce(new Vector2(0, -1) * powerJump);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            body.AddForce(new Vector2(0, 1) * powerJump);
            canJump = false;
        }

        x = PlayerPrefs.GetFloat("x");
        y = body.position.y;
        z = PlayerPrefs.GetFloat("z");

        if (y <= -13)
        {
            Vector3 LoadPosition = new Vector3(-7, -1, 0);
            transform.position = LoadPosition;
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
        loadingScene.LoadScene(1); //Goes back to farm
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
