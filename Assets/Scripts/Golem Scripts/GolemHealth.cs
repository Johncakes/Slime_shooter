using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHealth : MonoBehaviour
{
    public float health;
    GameObject healthbar;
    public GameObject player;
    public GameObject bullet;
    float healthscale;
    public int Intakedamage;


    private void Start()
    {
        healthscale = 1 / (health / Intakedamage);

        healthbar = GameObject.FindGameObjectWithTag("GolemHealth");
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void Update()
    {
        if ((player.GetComponent<player>().checkKilled() == true))
        {
            Destroy(gameObject);

        }



    }

    public void Takedamage(int damage)
    {
        //Debug.Log("takedamage is being used.");
        health -= damage;
       // Debug.Log(health);

        healthbar.transform.localScale -= new Vector3(healthscale, 0f,0f);

        if (health <= 0)
        {
            Die();
            player.GetComponent<player>().killedG();

        }
    }
    //Death
    void Die()
    {
        Destroy(gameObject);
    }

}
