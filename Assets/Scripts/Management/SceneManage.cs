using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject PlayerHealthPrefab;
    static bool playerExist = false;
    static bool PlayerHealthExist = false;

    static public float targetYlocation;
    float location;
    string player;
    static public bool Right = false;
    static public bool Left = false;

    CharacterController2D face;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 6)
        {
            if (playerExist == false)
            {
                Instantiate(playerPrefab, new Vector2(0, 0), Quaternion.identity);
                playerExist = true;
            }

            if (PlayerHealthExist == false)
            {
                Instantiate(PlayerHealthPrefab, new Vector2(0, 1), Quaternion.identity); 
                //Debug.Log("ran instantiate!");
                PlayerHealthExist = true;
            }

            //face = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();

            if (Right == true)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-8.3f, targetYlocation);
                // GameObject.FindGameObjectWithTag("Player").transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //face.switchFace();
                Right = false;
            }
            else if (Left == true)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(8.3f, targetYlocation);
                //GameObject.FindGameObjectWithTag("Player").transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                // face.switchFace();
                Left = false;
            }
        } 

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerExist);
       // Debug.Log(PlayerHealthExist);
        //Debug.Log(PlayerHealthPrefab.transform.position);
    }

    public void changenum(float n)
    {
        targetYlocation = n;
        //Debug.Log(targetYlocation);
    }

    public void setTrue(int n)
    {
        if (n == 1)
        {
            Right = true;
        }
        else if (n == 0)
            Left = true;
    }


    public void resetSetting()
    {
        playerExist = !playerExist;
        PlayerHealthExist = !PlayerHealthExist;
    }
}
