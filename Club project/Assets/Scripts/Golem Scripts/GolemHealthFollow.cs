using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHealthFollow : MonoBehaviour
{
    public Transform golem;
    player player;

    public float playerY = 0f;
    public float playerX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    // Update is called once per frame
    void Update()
    {


        // Debug.Log("player Alive: " + plyer.Alive);

        if (golem == true)
        {
            playerY = golem.transform.position.y + 1.4f;
            playerX = golem.transform.position.x;

            transform.position = new Vector2(playerX, playerY);

        }
        else
            Destroy(gameObject);

        if (player.checkKilled() == true)
        {
            Destroy(gameObject);
        }
    }
}
