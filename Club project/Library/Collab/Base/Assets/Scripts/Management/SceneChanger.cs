using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Transform Golem;
    Transform Player;

    static int sceneNum = 2;

    SceneManage sm;
    PlayerLife sg;
    player alive;

    // Start is called before the first frame update
    void Start()
    {

        sm = GameObject.Find("SceneManager").GetComponent<SceneManage>();
       
        

        //sg = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<PlayerLife>();


        /*if (sceneNum == -1)
        {
            sg.SearchGolem(true);
        }
        else if (sceneNum > -1)
            sg.SearchGolem(false);
    */

    }

    void Update()
    {

        
            alive = GameObject.FindWithTag("Player").GetComponent<player>();
       
        

        if (alive.AliveCheck() == true )
        {
           
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            
        }





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Golem == false)
        {
            float loca = collision.transform.position.y;
            sm.changenum(loca);

            //Debug.Log(collision.transform.position.x);

            if (Player.position.x > 0)
            {
                sm.setTrue(1);
                SceneManager.LoadScene(sceneNum + 1);
                sceneNum += 1;
                //Debug.Log("on the right");
                //Debug.Log("SceneNum : " + sceneNum);
            }
            else if (Player.position.x <= 0)
            {
                sm.setTrue(0);
                SceneManager.LoadScene(sceneNum - 1);
                sceneNum -= 1;
                //Debug.Log("on the left");
                //Debug.Log("SceneNum : " + sceneNum);
            }

            

        }

       
    }

}
