using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWalk : MonoBehaviour
{
    public GameObject character;
    private int change = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        character.transform.position = new Vector3(character.transform.position.x+0.01f,-1.92f,0);
       
    }
}
