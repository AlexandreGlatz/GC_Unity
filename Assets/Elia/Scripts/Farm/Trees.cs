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

    // Start is called before the first frame update
    void Start()
    {
        Tree_state = 1;
        
        if (first_start)
        {
            Time_Start = 3;
            count = 0;
            Harvestable = false;
        }
        Time_pass = Time_Start;
        Parent = this.gameObject.transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        Time_pass -= Time.deltaTime;
        if (Time_pass <= 0 && Tree_state < 5)
        {
            count += 1;
            animator.SetInteger("State", count);
            Time_pass = Time_Start;
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
            Destroy(this.gameObject);  
        }
    }
}
