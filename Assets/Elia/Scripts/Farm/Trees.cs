using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{

    public int Tree_state;
    public Animator animator;
    private bool first_start = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (first_start)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
