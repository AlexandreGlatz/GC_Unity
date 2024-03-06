using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentMoney : MonoBehaviour
{

    public static PlayerMovement instance;
    public Rigidbody2D body;
    public Animator animator;
    public float powerJump;

    public float x;
    public float y;
    public float z;
    public SpriteRenderer spriteRenderer;

    [Header("Currency")]
    public int currency = 0;
    TextMeshProUGUI MoneyUI;



    public void IncreaseCurrency(int amout)
    {
        currency += amout;
        MoneyUI.text = "Money : " + currency;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
