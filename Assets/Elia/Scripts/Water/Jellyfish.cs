using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "fish")
            {

                GameObject.Find("abyss fish").GetComponent<AnglerFish>().GetHit();
                Destroy(gameObject);
            }  
            
            if (collision.gameObject.tag == "Player")
            {
                GameObject.Find("player").GetComponent<playerwater>().Damage();
            }
    }
}
