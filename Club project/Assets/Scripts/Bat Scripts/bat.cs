using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    // vecter
    Vector3 muve;
    Vector3 velo = Vector3.zero;
    Vector3 after;

    // float
    public int Intakedamage;
    float a;
    float timeY;
    float timeX;
    float cooltime = 0;
    public float batHP = 300;
    float healthscale;
    float hill;
    int Descount;

    // int
    int b;

    // bool
    bool usingskill = false;
    bool l = true;

    // gameobject
    GameObject healthbar;
    public GameObject bullet;
    public GameObject cubbullet;

    player PL;

    // Start is called before the first frame update
    void Start()
    {
        muve = transform.position;

        a = Random.Range(1.0f, 2.0f);

        healthbar = GameObject.FindGameObjectWithTag("BatHealth");

        healthscale = 1 / (batHP / Intakedamage);

        hill = 0.24f / batHP;

        PL = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (usingskill != true)
        {
            timeY += Time.deltaTime;

            timeX += Time.deltaTime;

            if (timeY >= 3.14f)
            {
                a = Random.Range(1.0f, 3.0f);

                timeY = 0;
            }

            float x = 1.5f * Mathf.Sin(0.5f * timeX) + muve.x;

            float y = a * Mathf.Sin(2 * timeY) + muve.y;

            after = new Vector3(x, y);

            transform.position = after;
        }

            cooltime += Time.deltaTime;

        if (cooltime > 5.0f && usingskill != true)
        {
            usingskill = true;

            b =  Random.Range(1, 4);
        }

        /*if (batHP == 100)
        {
            usingskill = true;

            b = 4;
        }*/

        if (cooltime > 5.3f && usingskill == true)
        {
            if(b == 1)
            {
                wave();
            }
            else if(b == 2)
            {
                cub();
            }
            else if(b == 3)
            {
                rush();
            }
            else if(b == 4)
            {
                rest();
            }
            else
            {
                usingskill = false;
            }
            
        }
        if(batHP <= 0)
        {
            die();
        }

        if ((PL.GetComponent<player>().checkKilledB() == true))
        {
            Destroy(gameObject);

        }
    }

    float count = 0;
    float o = 1;

        //초음파 공격

    private void wave()
    {
        o += Time.deltaTime;

        if(o > 0.2)
        {
            Instantiate(bullet, transform.position, transform.rotation);

            count += 1;

            o = 0;
        }

        if(count >= 5)
        {
            usingskill = false;

            cooltime = 0;

            count = 0;
        }
    }

    Vector3 spawn;

        //새끼박쥐 공격

    private void cub()
    {
        o += Time.deltaTime;

        if(0.2f < o)
        {
            Instantiate(cubbullet);

            o = 0;

            count += 1;
        }

        if(count == 30)
        {
            usingskill = false;

            cooltime = 0;

            count = 0;
        }
    }

    float resttime = 0;

    Vector3 restvector = new Vector3(5.8f, 2.0f);

        //휴식패턴

    private void rest()
    {
        resttime += Time.deltaTime;

        batHP += 0.24f;

        healthbar.transform.localScale += new Vector3(hill, 0f, 0f);

        if (resttime < 15.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, restvector, 0.1f);
        }

        if(resttime > 15.1f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, after, ref velo, 1.2f);
        }

        if(resttime > 18.0f)
        {
            usingskill = false;

            resttime = 0;

            cooltime = 0;
        }
    }

    public float Rushtime = 0;

        //박쥐의 몸통박치기

    private void rush()
    {        
        Rushtime += Time.deltaTime;

        if(Rushtime < 1.2f)
        {
            this.transform.Translate(36.0f * Time.deltaTime, 0, 0);
        }

        if(Rushtime >= 1.2f && l == true)
        {
            transform.position = new Vector3(0, 10.0f, 0);

            l = false;
        }

        if(Rushtime >= 1.2f && l == false)
        {
            transform.position = Vector3.SmoothDamp(transform.position, after, ref velo, 0.5f);
        }

        if(Rushtime >=  3.4f)
        {
            Rushtime = 0;

            usingskill = false;

            cooltime = 0;

            l = true;
        }
    }

    public void die()
    {
        Destroy(gameObject);

        if(Descount == 0 && PL.killedBat == false)
        {
            PL.killedB();

            Descount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            batHP -= 1;

            healthbar.transform.localScale -= new Vector3(healthscale, 0f, 0f);
        }
    }
}