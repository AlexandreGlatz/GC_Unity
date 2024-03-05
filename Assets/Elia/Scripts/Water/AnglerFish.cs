using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : MonoBehaviour
{

    public float speed;
    public Rigidbody2D body;
    private int hp;
    public bool is_stun;
    private float timestart;
    private bool isinvincible;
    // Start is called before the first frame update
    void Start()
    {
        timestart = (float)1.5;
        hp = 10;
        is_stun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_stun)
        {
            Vector2 curentvelocity = new Vector2(0, 0);
            curentvelocity += new Vector2(1 * speed, 0);
            body.velocity = curentvelocity;
        }
        if (is_stun)
        {
            body.velocity = Vector2.zero;
        }

    }

    public void GetHit()
    {
        if (!isinvincible)
        {
            hp -= 1;
            StartCoroutine(Invincibility());
        }

        if (hp <= 0)
        {

            StartCoroutine(GetStunned());

        }


    }

    public IEnumerator Invincibility()
    {
        isinvincible = true;
        yield return new WaitForSeconds((float)0.5);
        isinvincible = false;

    }

    public IEnumerator GetStunned()
    {
        yield return new WaitForSeconds((float)1.5);
        is_stun = true;
    }
}
