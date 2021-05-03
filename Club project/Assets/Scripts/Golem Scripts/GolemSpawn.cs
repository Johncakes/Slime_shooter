using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpawn : MonoBehaviour
{
    public GameObject golemPrefab;
    public GameObject golemHealthPrefab;
    public bool spawnGolem = true;
    GameObject getplayer;
    // Start is called before the first frame update
    void Start()
    {
        getplayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
     {
            if (other.tag == "Player" && spawnGolem == true)
            {
                if (getplayer.GetComponent<player>().checkKilled() == false)
                {
                   Debug.Log(getplayer.GetComponent<player>().checkKilled() );
                    
                   Instantiate(golemPrefab, new Vector2(-7, -2), Quaternion.identity);
                   Instantiate(golemHealthPrefab, new Vector2(-7, -2), Quaternion.identity);
                   spawnGolem = false;
                }
          
            }
     } 
}
