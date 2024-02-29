using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balance : MonoBehaviour
{

    public int playerBalance;
    public int priceOfStructure;
    public bool isBought;
    public Rigidbody2D body;
    public float x;
    public float y;
    public float z;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isBought = false;
        body = GetComponent<Rigidbody2D>();

        if (playerBalance >= priceOfStructure)
        {
            playerBalance = playerBalance - priceOfStructure;
            isBought = true;

        }
        x = body.position.x;
        y = body.position.y;

        if (x < 25 )
    }
}
