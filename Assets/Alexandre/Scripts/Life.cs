using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int pv;
    bool isInvincible;
    private SpriteRenderer spriteRenderer;
    public Collider2D boarBody;
    public Collider2D playerBody;
    public LoadingScreen loadingScreen;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            pv -= damage;
            if (pv < 0)
            {
                Death();
            }

            StartCoroutine(Invincibility());
            
        }
        else
        {
            StartCoroutine(Blink());
            Physics2D.IgnoreCollision(boarBody, playerBody,true); // ignore collision with mob
        }
    }

    public IEnumerator Blink()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void Death()
    {
        loadingScreen.LoadScene(1);
    }

    public IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(2);

        isInvincible = false;
        Physics2D.IgnoreCollision(boarBody, playerBody, false);
    }
}
