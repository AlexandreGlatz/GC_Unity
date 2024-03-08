using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public int plot_number;
    public List<GameObject> Tree_type;
    public List<string> Tree_names;
    public float plot_price;
    public GameObject sign;
    public List<GameObject> seeds;
    public GameObject seed_selector;
    public List<GameObject> Choose;
    public int planted;  
    public bool plant_action;
    public GameObject enoughText;
    private GameObject aniseeds;

    public bool buy_plot;
    public List<bool> owned_plot;

    private bool first_start = true;
    private List<bool> locked_seeds;

    // Start is called before the first frame update
    void Start()
    {
        owned_plot = GameObject.Find("Sign").GetComponent<OwnedPlot>().owned_plot;
        aniseeds = GameObject.Find("Aniseeds");
        if (first_start)
        {
            planted = -1;
        }

        if (owned_plot[plot_number-1] == false) 
        {
            GameObject buying_sign = Instantiate(sign);
            buying_sign.transform.position = new Vector2(gameObject.transform.position.x,gameObject.transform.position.y);
            buying_sign.name = "Buy_sell"+plot_number;
            buying_sign.transform.SetParent(gameObject.transform);
        }

        GameObject.Find("PlayerUI").GetComponent<Canvas>().enabled = true;
    }
    
    // Update is called once per frame
    void Update()
    {

        if (plant_action == true)
        {
            PlantATree(planted);
            plant_action = false;   

        }

    }

    private void FixedUpdate()
    {

    }

    private void OnMouseDown()
    {
        bool boardlock = aniseeds.transform.GetChild(0).GetComponent<SeedElements>().isLocked;
        bool bearlock = aniseeds.transform.GetChild(1).GetComponent<SeedElements>().isLocked;
        bool birdlock = aniseeds.transform.GetChild(2).GetComponent<SeedElements>().isLocked;
        bool fishlock = aniseeds.transform.GetChild(3).GetComponent<SeedElements>().isLocked;
        locked_seeds = new List<bool> { bearlock, birdlock, boardlock, fishlock };

        if (owned_plot[plot_number - 1] && planted == -1)
        {
            Destroy(GameObject.FindWithTag("Seed_selector"));
            GameObject Seed_select = Instantiate(seed_selector);
            Seed_select.transform.position = gameObject.transform.position;
            Seed_select.name = "Seed_Selector";
            GameObject Seed_selector = GameObject.Find("Seed_Selector");
            Seed_selector.GetComponent<Choice_pannel>().plot_number = plot_number;

            List<(int x,float y)> position_list = new() { (-1, (float)0.5), (1, (float)0.5), (-1, -1), (1, -1) };
            List<(float x,float y)> icon_position = new () { (Seed_select.transform.localScale.x/4, Seed_select.transform.localScale.y/5) };

            for (int count = 0; count < locked_seeds.Count; count++)
            {

                if (!locked_seeds[count])
                {
                    GameObject seed = Instantiate(seeds[count]);
                    seed.transform.SetParent(Seed_select.transform);
                    seed.transform.position = Seed_select.transform.position + new Vector3(icon_position[0].x * position_list[count].x, icon_position[0].y * position_list[count].y, 0);
                    seed.GetComponent<Choice_icon>().icon_number = count;   
                }
                else
                {
                    GameObject Unknow = Instantiate(seeds[4]);
                    Unknow.transform.SetParent(Seed_select.transform);
                    Unknow.transform.position = Seed_select.transform.position + new Vector3(icon_position[0].x*position_list[count].x,icon_position[0].y *position_list[count].y,0);
                    Unknow.GetComponent<Choice_icon>().icon_number = count;
                }

            

            }


            GameObject Confirm = Instantiate(Choose[0]);
            GameObject Cancel = Instantiate(Choose[1]);
            Confirm.transform.SetParent(Seed_select.transform);
            Cancel.transform.SetParent(Seed_select.transform);
            Confirm.transform.position = Seed_select.transform.position + new Vector3(icon_position[0].x * -1, icon_position[0].y * (float)-2.25, 0);
            Cancel.transform.position = Seed_select.transform.position + new Vector3(icon_position[0].x * 1, icon_position[0].y * (float)-2.25, 0);


        }

    }

    void PlantATree(int tree_type)
    {
        if (GameObject.Find(Tree_names[tree_type]).GetComponent<SeedElements>().seedAmount > 0)
        {
           
            GameObject Tree = Instantiate(Tree_type[tree_type]);
            GameObject.Find(Tree_names[tree_type]).GetComponent<SeedElements>().seedAmount -= 1;
            Tree.transform.SetParent(GameObject.Find("Plot " + plot_number).transform);
            Tree.transform.position = gameObject.transform.position;
            Tree.transform.localScale = new Vector2(4, 4);
        } else { StartCoroutine(NotEnough()); }
    }

    public IEnumerator NotEnough()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(3);
        enoughText.SetActive(false);
    }

}
