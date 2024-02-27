using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private DefaultPlayerActions _DefaultPlayerAtions;

    private InputAction _moveAction;
    private InputAction _lookAction;
    
    private void Awake()
    {
        _DefaultPlayerAtions = new DefaultPlayerActions();
    }

    private void OnEnable()
    {
        _moveAction = _DefaultPlayerAtions.Player.Move; 
        _moveAction.Enable();
        _lookAction = _DefaultPlayerAtions.Player.Look;
        _lookAction.Enable();
        _DefaultPlayerAtions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _lookAction.Disable();
        _DefaultPlayerAtions.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = _moveAction.ReadValue<Vector2>();

        Vector2 lookDir = _moveAction.ReadValue<Vector2>();

    }














    /* Start is called before the first frame update
    void Start()
    {
        
    }

    public Rigidbody2D body;
    public float powerJump;
    public float moveSpeed;
    int maxJump = 3;
    int currentJump = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = new Vector2(0, body.velocity.y);
        if (currentJump < maxJump) {

            if (Input.GetKey(KeyCode.D))
            {
                currentVelocity += new Vector2(moveSpeed, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                currentVelocity += new Vector2(-moveSpeed, 0);
            }

            body.velocity = currentVelocity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(new Vector2(0, 1) * powerJump);
                currentJump++;
            }
        }
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            currentJump = 0;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }*/

}
