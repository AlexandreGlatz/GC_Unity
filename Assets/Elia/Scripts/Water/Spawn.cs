using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    private System.Random random;
    public GameObject spawner;
    public GameObject follow;
    public GameObject objectToSpawn;
    private float halflength,startpos;
    private float distance;
    private List<Vector2> allitems = new List<Vector2>();
    private Vector2 spawn_position;
    private int Kelp_counter;
    private Vector3 screen_top, screen_bottom;
    private List<Vector2> spawn_height;


    // Start is called before the first frame update


    void Start()
    {  
        Camera cam = Camera.main;
        halflength = (cam.orthographicSize * cam.aspect);
        startpos = 0;
        distance = halflength;
        allitems.Clear();
        Destroy(GameObject.FindWithTag("Jelly_fish"));
        Kelp_counter = 0;
        screen_top = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screen_bottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        float screen_height = 2*cam.orthographicSize;
        float screen_3 = screen_height / 3;
        Vector2 top_zone = new Vector2(screen_top[1], screen_top[1] - screen_3);
        Vector2 mid_zone = new Vector2(screen_top[1] - screen_3, screen_bottom[1] + screen_3);
        Vector2 bottom_zone = new Vector2(screen_bottom[1] + screen_3, screen_bottom[1]);
        spawn_height = new List<Vector2>();

        spawn_height.Add (top_zone);spawn_height.Add(mid_zone);spawn_height.Add(bottom_zone);

    }


    // Update is called once per frame
    void Update()
    {
        random = new System.Random();


        if (follow.transform.position.x - startpos > distance) 
        {
            SpawnItem();
            startpos += distance;
        }



        if (allitems.Count != 0){
            DeleteItem(allitems);
        }

    }

    void SpawnItem()
    {

        for (int count = 0; count < 3; count++)
        {

            Instantiate(objectToSpawn);
            Kelp_counter += 1;
            objectToSpawn.name = "Jelly_fish" + Kelp_counter;

            Vector2 position_y = spawn_height[count];
            System.Random random = new System.Random();
            double random_position = ( (random.NextDouble() * (position_y[0] - position_y[1]) ) + position_y[1]);
            float random_position_y = Convert.ToSingle(random_position);   


            int random_size = random.Next(2, 4);
            objectToSpawn.transform.localScale = new Vector3(random_size,random_size, random_size); 
            objectToSpawn.transform.position = new Vector3(follow.transform.position.x + halflength * 2,random_position_y, 0);
            spawn_position = new Vector2(Kelp_counter, objectToSpawn.transform.position.x);
            allitems.Add(spawn_position);
        }
    }

    void DeleteItem(List<Vector2> list)
    {
        for(int count = 0; count < allitems.Count; count++) 
        {
            if (list[count][1] < follow.transform.position.x - halflength)
            {   
                GameObject todestroy = GameObject.Find("Jelly_fish" + list[count][0]+"(Clone)");
                Destroy(todestroy);
                list.RemoveAt(count);

            }
        }
    }
}
