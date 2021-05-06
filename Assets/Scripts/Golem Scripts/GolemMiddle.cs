using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMiddle : MonoBehaviour
{

    GameObject Player;
    golem facing;

    // Start is called before the first frame update
    void Start()
    {
        facing = GameObject.FindGameObjectWithTag("Enemy").GetComponent<golem>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform != null)
        {
            if (Player.transform.position.x > transform.position.x)
            {
                facing.Looking(true);
            }
            else if (Player.transform.position.x < transform.position.x)
            {
                facing.Looking(false);
            }

        }

    }
}
