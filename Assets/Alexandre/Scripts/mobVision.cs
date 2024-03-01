using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobVision : MonoBehaviour
{
    public mobBehavior boar;

    private void Update()
    {
        boar.playerSeen = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            boar.playerSeen = true;
        }
    }

}
