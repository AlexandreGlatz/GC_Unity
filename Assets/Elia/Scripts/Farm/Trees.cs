using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Trees : MonoBehaviour
{

    public int Tree_state;
    public Animator animator;
    private bool first_start = true;
    float Time_Start;
    float Time_pass;
    int count;
    bool Harvestable;
    GameObject Parent;
    bool new_state;
    float tree_time_upgrade;
    public string tree_type;

    // Start is called before the first frame update
    void Start()
    {
        Tree_state = 1;
        
        if (first_start)
        {
            count = 0;
            Harvestable = false;
        }
        Time_pass = Time_Start;
        Parent = this.gameObject.transform.parent.gameObject;
        tree_time_upgrade = 0;
        new_state = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (new_state && count<5)
        {
            StartCoroutine(Waitfornewstate());
            animator.SetInteger("State", count);
            count += 1;
            Tree_state += 1;
        }
        if (Tree_state == 5)
        {
            Harvestable = true;
        }
    }

    private void OnMouseDown()
    {
        if (Harvestable)
        {
            Parent.GetComponent<Plot>().planted = -1;
            GameObject.Find(tree_type).GetComponent<SeedElements>().seedAmount += 1;
            GameObject.Find(tree_type).GetComponent<SeedElements>().fruitAmount += 4;
            Destroy(this.gameObject);  
        }
    }

    public IEnumerator Waitfornewstate()
    {
        new_state = false;
        yield return new WaitForSeconds(5-tree_time_upgrade);
        new_state = true;
    }
}
