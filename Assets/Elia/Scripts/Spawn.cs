using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{

    public GameObject spawner;
    public GameObject follow;
    public GameObject objectToSpawn;
    private float halflength,startpos;
    private float distance;
    private Vector2[] allitems;

    // Start is called before the first frame update


    void Start()
    {

        Camera cam = Camera.main;
        halflength = (cam.orthographicSize * cam.aspect);
        startpos = follow.transform.position.x;
        distance = 5;
    }


    // Update is called once per frame
    void Update()
    {
        if (follow.transform.position.x - startpos > distance) 
        {
            SpawnItem();
            startpos += distance; 
        }

    }

    void SpawnItem()
    {
        Instantiate(objectToSpawn);
        objectToSpawn.transform.position = spawner.transform.position;
        allitems = allitems.Append(new Vector2(objectToSpawn.transform.position.x,objectToSpawn.transform.position.y)).ToArray();
        Console.WriteLine(allitems);
    }

    void DeleteItem()
    {
        
    }
}
