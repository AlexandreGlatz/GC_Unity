using TMPro;
using UnityEngine;
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
    public SpriteRenderer spriteRenderer;

    [Header("Currency")]
    public int currency = 0;
    public TextMeshProUGUI MoneyUI;

    Camera camera;


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
        camera = Camera.main;

        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(new Vector2(0, 1) * powerJump);
        }


        y = body.position.y;
        z = PlayerPrefs.GetFloat("z");
        x = body.position.x;

        if (y <= (float)-7.2)
        {
            Vector3 LoadPosition = new Vector3(0, -2, 0);
            transform.position = LoadPosition;
        }

        if (x >= (float)12.1)
        {
            Vector3 LoadPosition = new Vector3((float)-12, gameObject.transform.position.y, 0);
            transform.position = LoadPosition;
        }

        if (x <= (float)-12.1)
        {
            Vector3 LoadPosition = new Vector3((float)12, gameObject.transform.position.y, 0);
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

    }

}
