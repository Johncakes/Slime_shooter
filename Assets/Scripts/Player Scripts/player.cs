using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{

    public CharacterController2D Control;
    public float speed;
    public float dashtime = 1f;
    public Animator anim;

    bool jump = false;
    public bool pot = false;
    public bool Alive = true;
    public bool killedGolem = false;
    public bool killedBat = false;

    float horizontalmove = 0f;
    float playerY = 0f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // player speed checker
        if (jump == false)
        {
            speed = 35f;
        }

        playerY = transform.position.y;

        playerMovement();

        win();

        jumping();

        PlayerDash();

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Killed Golem = " + killedGolem);
            Debug.Log("Killed bat = " + killedBat);
            Debug.Log("Current Scene = " + SceneManager.GetActiveScene().buildIndex);
        }
        //Debug.Log("Player Alive = " + Alive);

    }

    void playerMovement()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
    }

    void PlayerDash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && jump == true)
        {
            dashtime -= Time.deltaTime;
            speed = 70f;

            // Debug.Log("Dashed");
            if (Input.GetKeyUp(KeyCode.LeftShift) || dashtime <= 0)
            {
                speed = 35f;
            }
        }

    }

    void jumping()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            anim.SetBool("Isjumping", true);
        }
    }

    public void onland()
    {
        dashtime = 0.8f;
        jump = false;
        anim.SetBool("Isjumping", false);
    }

    private void FixedUpdate()
    {
        Control.Move(horizontalmove * Time.fixedDeltaTime, false, jump);

        // jump = false;
    }

    public bool AliveCheck()
    {
        if (Alive == true)
        {
            return true;
        }
        else
            return false;


    }

    public void killedG()
    {
        killedGolem = !killedGolem;
    }

    public void killedB()
    {
        killedBat = !killedBat;
    }

    public bool checkKilled()
    {
        if (killedGolem == true)
        {
            return true;
        }
        else
            return false;
    }

    public bool checkKilledB()
    {
        if (killedBat == true)
        {
            return true;
        }
        else
            return false;
    }

    public void gotPot()
    {
        pot = !pot;
    }

    public bool checkPot()
    {
        if (pot == true)
        {
            return true;
        }
        else
            return false;
    }

    public void win ()
    {
        if (killedGolem == true && killedBat == true)
        {
            SceneManager.LoadScene("Win scene");

            Destroy(gameObject);
        }
    }

}


