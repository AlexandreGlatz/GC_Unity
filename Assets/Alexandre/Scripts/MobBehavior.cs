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
    public MobLife mobLife;
    public Animator parentAnim;

    public int boarHp = 3;
    public int boarDamage = 1;
    public int strength = 250;
    public int wallImpact = 15000;
    public float initialMoveSpeed = 1;

    public bool walkDir = true; //true = left false = right
    public bool isCaptured = false;
    public bool playerSeen;
    public bool isCharging = false;
    public bool wallTouched = false;
    public bool isDead = false;
    public bool canWalk = true; 

    private bool isAttacking = false;
    private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Walk();
        }

        if (isCaptured)
        {
            parentAnim.SetTrigger("isCaptured");
            animator.SetTrigger("isCaptured");
        }
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
            mobLife.TakeDamage();
            if (isDead)
            {
                wallImpact = 1;
            }
            if (walkDir)
            {
                boarBody.AddForce(new Vector2(-1, 1) * wallImpact);
            }
            else
            {
                boarBody.AddForce(new Vector2(1, 1) * wallImpact);
            }
            
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
        //flip upon touching wall
        if (collision.gameObject.tag == "wall")
        {
            transform.Rotate(0,transform.rotation.y-180, 0);
            wallTouched = true;
            walkDir = !walkDir;

        }

        //player hit
        if (collision.gameObject.tag=="player" && !isDead)
        {
            StartCoroutine(Hit());
            life.TakeDamage(boarDamage);
            if (isAttacking)
            {
                isAttacking = false;
                canWalk = true;
                animator.ResetTrigger("isCharging");
            }
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
