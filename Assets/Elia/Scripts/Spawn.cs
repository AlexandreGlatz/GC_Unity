using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{

    public GameObject spawner;
    public GameObject follow;
    public GameObject objectToSpawn;
    private float halflength,startpos;
    private float distance;
    private List<Vector2> allitems = new List<Vector2>();
    private Vector2 spawn_position;
    private int Kelp_counter;
    private int side;

    // Start is called before the first frame update


    void Start()
    {  
        Camera cam = Camera.main;
        halflength = (cam.orthographicSize * cam.aspect);
        startpos = spawner.transform.position.x;
        distance = halflength;
        Kelp_counter = 0;   
    }


    // Update is called once per frame
    void Update()
    {
        if (follow.transform.position.x - startpos < distance*-1) 
        {
            side = -1;
            SpawnItem(side);
        } else if (follow.transform.position.x - startpos > distance)
        {

            side = 1;
            SpawnItem(side);
            startpos += distance;
        }



        if (allitems.Count != 0){
            DeleteItem(allitems);
        }

    }

    void SpawnItem(int side)
    {
        Instantiate(objectToSpawn);
        Kelp_counter += 1;
        objectToSpawn.name = "Kelp"+Kelp_counter;
        objectToSpawn.transform.position = new Vector3(spawner.transform.position.x + (halflength*side),spawner.transform.position.y,0);
        spawn_position = new Vector2(Kelp_counter, objectToSpawn.transform.position.x);
        allitems.Add(spawn_position);
        print(String.Join("; ", allitems));
    }

    void DeleteItem(List<Vector2> list)
    {
        for(int count = 0; count < allitems.Count; count++) 
        {
            if (list[count][1] > follow.transform.position.x + halflength || list[count][1] < follow.transform.position.x - halflength)
            {
                GameObject todestroy = GameObject.Find("Kelp" + list[count][0]+"(Clone)");
                Destroy(todestroy);
                list.RemoveAt(count);

            }
        }
    }
}
