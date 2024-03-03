using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobLife : MonoBehaviour
{

    public Animator animator;
    public mobBehavior mobBehavior;
    public Collider2D boarBody;
    public Collider2D playerBody;

    public int mobHp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        mobHp -= 1;

        if (mobHp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        animator.SetTrigger("isDead");
        mobBehavior.isDead = true;
        Physics2D.IgnoreCollision(boarBody, playerBody, true);
    }
}
