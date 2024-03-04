using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirm : MonoBehaviour
{
    private GameObject Parent;
    private int Plot_number;
    List<bool> choosen_seed;
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
        choosen_seed = Parent.GetComponent<Choice_pannel>().choosen_seed;
        GameObject Plot = GameObject.Find("Plot " + Plot_number);
        print(choosen_seed.IndexOf(true));
        Plot.GetComponent<Plot>().planted =choosen_seed.IndexOf(true);
        Plot.GetComponent<Plot>().plant_action = true;

        Destroy(GameObject.Find("Seed_Selector"));
    }
}
