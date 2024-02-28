using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float length, startpos, startposY;
    public GameObject cam;
    public float parallaxEffect;



    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector2(startpos + distance, startposY);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}