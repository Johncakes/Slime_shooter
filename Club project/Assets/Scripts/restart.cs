using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour
{
    AudioSource click;
    BGM bgm;

    public void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>();
    }
    public void RestartButton()
    { 
        
        SceneManager.LoadScene("Starting Scne");
        //bgm.startmusic();
        //Debug.Log("Restart music");
        
    }

}
