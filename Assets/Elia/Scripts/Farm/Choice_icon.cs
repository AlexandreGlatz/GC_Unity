using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_icon : MonoBehaviour
{

    public bool on_click = false;
    public int icon_number;
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
        if (gameObject.tag != "Unknown")
        {
            on_click = true;
        }    
    }

}
