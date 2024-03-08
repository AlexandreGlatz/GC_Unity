using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class checkpinfo : MonoBehaviour
{
    private List<GameObject> check;
    // Start is called before the first frame update
    void Start()
    {
        check = new List<GameObject>();
        for (int i = 0; i < 2; i++) 
        {
            if (GameObject.Find("PlayerInfos"))
            {
                check.Add(GameObject.Find("PlayerInfos"));
                GameObject.Find("PlayerInfos").name = "PlayerInfos" + i;
            }
        }

        if (check.Count > 1)
        {
            Destroy(GameObject.Find("PlayerInfos1"));
        }

        GameObject.Find("PlayerInfos0").name = "PlayerInfos";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
