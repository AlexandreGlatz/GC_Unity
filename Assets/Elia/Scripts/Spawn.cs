using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject spawn;
    private DateTime Datetimebegin;
    private bool spawned_item;

    // Start is called before the first frame update


    void Start()
    {
        Datetimebegin = DateTime.Now;
        spawned_item = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (spawned_item == false)
        {
            SpawnObject(spawned_item);
        }
    }

    void SpawnObject(bool spawned)
    {
        DateTime Datecycle = DateTime.Now;

        long elapsedticks = Datetimebegin.Ticks - Datecycle.Ticks;
        TimeSpan elapsedtime = new TimeSpan(elapsedticks);
        if (elapsedtime.TotalSeconds > 60)
        {
            GameObject newObject = Instantiate(spawn);
            spawned = true;

        }
    }
}
