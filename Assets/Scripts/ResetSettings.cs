using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSettings : MonoBehaviour
{
    SceneManage sm;
    SceneChanger sc;

    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneManage>();
        sc = GameObject.FindGameObjectWithTag("SceneChange").GetComponent<SceneChanger>();

        sm.resetSetting();
        sc.resetscene();

     



    }
}
