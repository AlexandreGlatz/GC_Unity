using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Plot : MonoBehaviour
{

    float money_data;
    int money;
    public int sign_price;
    float plot_data;
    List<bool> owned_plot;
    public int sign_number;
    private GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        Parent = this.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        money = GameObject.Find("Shop").GetComponent<SellShop>().money;
        owned_plot = Parent.GetComponent<Plot>().owned_plot;
        if (money >= sign_price)
        {
            owned_plot[sign_number] = true;
            Destroy(gameObject);
            GameObject.Find("Shop").GetComponent<SellShop>().money -= sign_price;
        }
    }
}
