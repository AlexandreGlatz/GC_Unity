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
    public void TakeDamage(int damage)
    {
        pv -= damage;

        if (pv < 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
