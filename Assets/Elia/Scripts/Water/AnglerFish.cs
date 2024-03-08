using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnglerFish : MonoBehaviour
{

    public bool isCaptured;
    public GameObject rock;
    public float speed;
    public Rigidbody2D body;
    private int hp;
    public bool is_stun;

    private bool isinvincible;
    public Animator animator;
    private bool stunned;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        is_stun = false;
        stunned = false;
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
        if (is_stun && !stunned)
        {
            stunned = true; 
            gameObject.transform.GetChild(0).GetComponent<Light2D>().enabled = false;
            body.velocity = Vector2.zero;
            BoxCollider2D Boxcollider = gameObject.GetComponent<BoxCollider2D>();
            Boxcollider.size = new Vector2((float)4.4, Boxcollider.size.y); 
            Boxcollider.offset = new Vector2(0, Boxcollider.offset.y);

            GameObject Barrer = Instantiate(rock);
            Barrer.transform.position = new Vector3(this.gameObject.transform.position.x + 15, -5, 0);
        }

        if (isCaptured)
        {
            animator.SetTrigger("IsCaptured");
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
            animator.SetTrigger("Stunned");

        }


    }

    public IEnumerator Invincibility()
    {
        isinvincible = true;
        animator.SetTrigger("Damage");
        yield return new WaitForSeconds(1);
        isinvincible = false;
        animator.ResetTrigger("Damage");

    }

    public IEnumerator GetStunned()
    {
        yield return new WaitForSeconds((float)1);
        is_stun = true;



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("player").GetComponent<playerwater>().Contactwithfish();
        }
    }
}
