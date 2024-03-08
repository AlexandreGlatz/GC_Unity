using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    private GameObject Parent;
    private int Plot_number;
    List<bool> choosen_seed;
    bool on_click;


    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.Find("Seed_Selector");
        Plot_number = Parent.GetComponent<Choice_pannel>().plot_number;
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        on_click = GameObject.Find("Seed_Selector").GetComponent<Choice_pannel>().icon_clicked;
        if (on_click)
        {
            choosen_seed = Parent.GetComponent<Choice_pannel>().choosen_seed;
            GameObject Plot = GameObject.Find("Plot " + Plot_number);
            GameObject.Find("Seed_Selector").GetComponent<Choice_pannel>().Destroypannel();

            Plot.GetComponent<Plot>().planted = choosen_seed.IndexOf(true);
            Plot.GetComponent<Plot>().plant_action = true;

        }
    }
}
