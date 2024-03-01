using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBag : MonoBehaviour{
    public int worth = 100;

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player"){
                GameObject moneybag = GameObject.Find("MoneyBag");
                Destroy(moneybag);

                PlayerMovement.instance.IncreaseCurrency(worth);
        }
    }
}