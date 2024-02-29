using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="boar") 
        {
            //GetComponent<componentrecherche>()
            collision.gameObject.GetComponent<Life>().TakeDamage(damage);
        }
    }

    
}
