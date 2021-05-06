using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batHealthFollow : MonoBehaviour
{
    public Transform bat;
    player PL;

    float playerY;
    float playerX;

    // Start is called before the first frame update
    void Start()
    {
        PL = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (bat == true)
        {
            playerY = bat.transform.position.y + 3.0f;
            playerX = bat.transform.position.x;

            transform.position = new Vector2(playerX, playerY);
        
        }
        else
            Destroy(gameObject);
    }
}
