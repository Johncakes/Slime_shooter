using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPot : MonoBehaviour
{
    PlayerLife health;
    player player;
    public int HealAmount;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();

        if (player.checkPot() == true)
        {
            Destroy(gameObject);
        }
    }

    //Increase players health when taken.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (health.returnHealth() < 10)
            {
                health.increaseHealth(HealAmount);
                player.gotPot();
                Destroy(gameObject);
            }
        }
       
    }

}
