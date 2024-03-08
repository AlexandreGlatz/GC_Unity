using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    private System.Random random;
    public GameObject rock;
    public GameObject spawner;
    public GameObject follow;
    public GameObject objectToSpawn;
    private float halflength,startpos;
    private float distance;
    private List<Vector2> allitems = new();
    private Vector2 spawn_position;
    public int Kelp_counter;
    private Vector3 screen_top, screen_bottom;
    private List<Vector2> spawn_height;
    private int maxspawn;

    bool Ghostdestroy;



    // Start is called before the first frame update


    void Start()
    {  
        Camera cam = Camera.main;
        halflength = (cam.orthographicSize * cam.aspect);
        startpos = 0;
        distance = halflength;
        //allitems.Clear();

        for (int i = 0; i < allitems.Count; i++)
        {
            allitems.RemoveAt(0);
        }
        Kelp_counter = 0;
        //(allitems.Count());

        //Destroy(GameObject.FindWithTag("Jelly_fish"));
        
        screen_top = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screen_bottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        float screen_height = 2*cam.orthographicSize;
        float screen_3 = screen_height / 4;
        Vector2 top_zone = new(screen_top[1]+1, screen_top[1] - screen_3);
        Vector2 mid_zone = new(screen_top[1] - screen_3, screen_bottom[1] + screen_3);
        Vector2 bottom_zone = new (screen_bottom[1] + screen_3, screen_bottom[1]-1);
        spawn_height = new();

        spawn_height.Add (top_zone);spawn_height.Add(mid_zone);spawn_height.Add(bottom_zone);
        maxspawn = 10;
        Ghostdestroy = false;
    }


    // Update is called once per frame
    void Update()
    {
        random = new System.Random();


        if (maxspawn > 0)
        {
            if (follow.transform.position.x - startpos > distance)
            {
                SpawnItem();
                startpos += distance;
                maxspawn -= 1;
            }

        }


        if (!Ghostdestroy)
        { 
            if (GameObject.FindWithTag("Jelly_fish")){
                Ghost_fish(GameObject.FindWithTag("Jelly_fish"));
            }
        }


    }

    void Ghost_fish(GameObject jelly)
    {

            if (jelly.name != "Jelly_fish 1(Clone)")
            {
                Destroy(jelly);
                Ghostdestroy = true;
            }  else { Ghostdestroy = true; }      
    }

    void SpawnItem()
    {
        Kelp_counter += 1;
        for (int count = 0; count < 3; count++)
        {

            Instantiate(objectToSpawn);
            objectToSpawn.name = "Jelly_fish" + Kelp_counter;

            Vector2 position_y = spawn_height[count];
            System.Random random = new();
            double random_position = ((random.NextDouble() * (position_y[0] - position_y[1])) + position_y[1]);
            float random_position_y = Convert.ToSingle(random_position);


            int random_size = random.Next(2, 4);
            objectToSpawn.transform.localScale = new Vector3(random_size, random_size, random_size);
            objectToSpawn.transform.position = new Vector3(follow.transform.position.x + halflength * 2, random_position_y, 0);
            spawn_position = new Vector2(Kelp_counter, objectToSpawn.transform.position.x);

            objectToSpawn.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, (float)0.63);

            allitems.Add(spawn_position);

        }

        
        }
    }


