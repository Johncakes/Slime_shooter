using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthFollow : MonoBehaviour
{
    Transform player;

    public float playerY = 0f;
    public float playerX = 0f;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {


        // Debug.Log("player Alive: " + plyer.Alive);

        if (player != null)
        {
            playerY = player.transform.position.y + 0.65f;
            playerX = player.transform.position.x;

            transform.position = new Vector2(playerX, playerY);

        }
        else if (player == null)
        {
            
            Destroy(gameObject);
        }
    }
}
