using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Plot : MonoBehaviour
{

    SellShop money_data;
    int money;
    public int sign_price;
    Plot plot_data;
    List<bool> owned_plot;
    public int sign_number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        money = money_data.money;
        owned_plot = plot_data.owned_plot;
        if (money >= sign_price)
        {
            owned_plot[sign_number] = true;
            Destroy(gameObject);
        }
    }
}
