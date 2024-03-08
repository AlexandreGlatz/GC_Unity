using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_pannel : MonoBehaviour
{
    public int plot_number;
    public List<bool> choosen_seed;
    private List<GameObject> all_childs;
    private Choice_icon choice_icon_script;
    public bool icon_clicked;

    // Start is called before the first frame update
    void Start()
    {
        all_childs = new List<GameObject>();
        for (int count = 0;count<4;count++) 
        {
            GameObject child = this.gameObject.transform.GetChild(count).gameObject;
            all_childs.Add(child);
        }
        choosen_seed = new List<bool> { false,false,false,false};
        GameObject.Find("Plot "+plot_number).GetComponent<CircleCollider2D>().enabled = false;
        icon_clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool reset_icon = false;
        int clicked = -1;
        for (int count = 0; count < 4; count++)
        {
            choice_icon_script = all_childs[count].GetComponent<Choice_icon>();

            if (choice_icon_script.on_click == true)
            {
                choice_icon_script.on_click = false;
                icon_clicked = true;
                reset_icon = true;
                clicked = count;
                count = 0;

            }

            if (reset_icon) 
            {
                all_childs[count].GetComponent<SpriteRenderer>().color = Color.white;
                all_childs[clicked].GetComponent<SpriteRenderer>().color = Color.green;
            }
            

        }
        if (reset_icon)
        {
            choosen_seed = new List<bool> { false, false, false, false };
            choosen_seed[clicked] = true;
        }

    }

    public void Destroypannel()
    {
        GameObject.Find("Plot " + plot_number).GetComponent<CircleCollider2D>().enabled = true;
        Destroy(gameObject);
    }
}
