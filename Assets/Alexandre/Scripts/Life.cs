using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public int pv;
    bool isInvincible;

    public void TakeDamage(int damage)
    {
        if (isInvincible)
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
            print("jsuis invincible");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(2);

        isInvincible = false;
    }
}
