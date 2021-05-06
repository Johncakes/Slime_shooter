using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinTrack : MonoBehaviour
{
    bool won = false;
    int WonAmount = 0;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (won == true)
            {
                WonAmount++;
                won = !won;
            }
        }
    }
}
