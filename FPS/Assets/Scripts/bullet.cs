using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject player1;
    private bool Dead1;
    private bool Dead2;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
        Dead1 = false;
        Dead2 = false;
    }

    private void OnTriggerEnter2D(Collider2D attacked)
    {
        if(attacked.tag == "Player1")
        {
            if(gameObject.tag == "Bullet2")
            {
                if(Dead1 == false)
                {
                    Taked1(1);
                }

                if(Dead1 == true)
                {
                    Destroy(attacked.gameObject);
                }
            }
        }

        if (attacked.tag == "Player2")
        {
            if (gameObject.tag == "Bullet1")
            {
                if (Dead2 == false)
                {
                    Taked2(1);
                }

                if (Dead2 == true)
                {
                    Destroy(attacked.gameObject);
                }
            }
        }

        Destroy(gameObject);

        void Taked1(int Damage)
        {
            GameObject p1 = GameObject.FindGameObjectWithTag("Player1");
            p1.GetComponent<ARROW>().CH -= Damage;

            GameObject healthb = GameObject.FindGameObjectWithTag("HB");
            healthb.GetComponent<HealthBar>().Sethealth(p1.GetComponent<ARROW>().CH);

            if(p1.GetComponent<ARROW>().CH <= 0)
            {
                Dead1 = true;
            }
        }
        
        void Taked2(int Damage)
        {
            GameObject p2 = GameObject.FindGameObjectWithTag("Player2");
            p2.GetComponent<WASD>().CH -= Damage;

            GameObject healthb = GameObject.FindGameObjectWithTag("HB2");
            healthb.GetComponent<HealthBar>().Sethealth(p2.GetComponent<WASD>().CH);

            if(p2.GetComponent<WASD>().CH <= 0)
            {
                Dead2 = true;
            }
        }
    }
}
