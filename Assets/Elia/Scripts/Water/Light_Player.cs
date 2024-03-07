using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_Player : MonoBehaviour
{

    private bool isdead;
    private bool lighton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isdead = GameObject.Find("player").GetComponent<playerwater>().isdead;
        if (isdead)
        {
            gameObject.GetComponent<Light2D>().intensity -= (float)0.001; 

        }

        if (GameObject.Find("Head_light (1)").GetComponent<Light2D>().intensity <= 0)
        {
            GameObject.Find("player").GetComponent<playerwater>().lighton = false;
        }
    }
}
