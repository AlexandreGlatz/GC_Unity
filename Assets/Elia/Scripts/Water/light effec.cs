using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_effec : MonoBehaviour
{
    private float halflength,length, startpos;
    public GameObject follow;
    public float parallaxEffect;



    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        halflength = (cam.orthographicSize * cam.aspect);
        length = halflength * 6;
        startpos = halflength;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        float temp = (follow.transform.position.x * (1 - parallaxEffect));
        float distance = (follow.transform.position.x * parallaxEffect);
        transform.position = new Vector2(startpos + distance, transform.position.y);

        if (temp+halflength > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length - halflength;
        }
    }
}
