using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    AudioSource bgm;
    player player;

    // Start is called before the first frame update
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        bgm = GetComponent<AudioSource>();

        
       
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();

        if ((SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6) )
        {
            bgm.Stop();
            Destroy(gameObject);
            Debug.Log("Stop muisc");
        }
    }

    public void startmusic()
    {
        //Invoke("bgm.Play()", 10);
        bgm.Play();
        Debug.Log("Play Music");
    }
}
