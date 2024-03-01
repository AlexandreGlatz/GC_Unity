using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class mobBehavior : MonoBehaviour
{

    public Rigidbody2D boarBody;
    public Animator animator;
    public playerMovement player;
    public Life life;

    public int boarDamage = 1;
    public int strength = 250;
    public float initialMoveSpeed;

    public bool playerSeen;
    public bool isCharging = false;
    public bool wallTouched = false;

    private bool canWalk = true; //true = left false = right
    private bool walkDir = true;
    private bool isAttacking = false;
    private float moveSpeed;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        ///Walking behaviour
        moveSpeed = initialMoveSpeed;
        
        Vector2 currentVelocity = new Vector2(0, boarBody.velocity.y);

        //Walk left
        if (canWalk && walkDir)
        {
            //moves
            currentVelocity += new Vector2(-moveSpeed, 0);
            wallTouched = false;
            boarBody.velocity = currentVelocity;
        }

        //WalkRight
        else if (canWalk && !walkDir)
        {
            currentVelocity += new Vector2(moveSpeed, 0);
            wallTouched = false;
            boarBody.velocity = currentVelocity;
        }

        if (wallTouched && isAttacking)
        {
            isAttacking = false;
            canWalk = true;
            animator.ResetTrigger("isCharging");
        }



        //Attack when player is seen in boar's cone of vision
        if (playerSeen && !isAttacking)
        {
            isAttacking = true;
            canWalk = false;
            StartCoroutine(ChargingCharge());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            ///flip upon touching wall
            
            transform.Rotate(0,transform.rotation.y-180, 0);
            wallTouched = true;
            walkDir = !walkDir;


        } 


        if (collision.gameObject.tag=="player")
        {
            ///player hit
            StartCoroutine(Hit());
            life.TakeDamage(boarDamage);
        }
    }

    public IEnumerator ChargingCharge()
    {
        ///time to charge an attack
        boarBody.velocity = new Vector2(0, 0);
        animator.SetTrigger("isCharging");
        yield return new WaitForSeconds(1);
        if (walkDir)
        {
            boarBody.velocity = new Vector2(-15, 0);
        }

        else
        {
            boarBody.velocity = new Vector2(15, 0);
        }
    }

    public IEnumerator Hit()
    {
        ///time to attack
        animator.SetTrigger("hitPlayer");
        life.TakeDamage(boarDamage);
        player.getHit(strength);
        yield return new WaitForSeconds(1);
        animator.ResetTrigger("hitPlayer");
    }

}
