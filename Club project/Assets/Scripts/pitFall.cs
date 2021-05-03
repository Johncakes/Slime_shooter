using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitFall : MonoBehaviour
{
    PlayerLife Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.Die();
            Debug.Log("Executed Comand 'Death'.");
        }
    }
}

