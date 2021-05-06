using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    AudioSource click;
    BGM bgm;

    private void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<BGM>();
    }
    public void StartButton()
    {
        click = GetComponent<AudioSource>();
        click.Play();
        SceneManager.LoadScene("Middle");
        bgm.startmusic();
    }

    public void cons()
    {
        SceneManager.LoadScene("Cons");
    }

    public void startMenu()
    {
        SceneManager.LoadScene("Starting scne");
    }

    public void quit()
    {
        Application.Quit();
    }

}
