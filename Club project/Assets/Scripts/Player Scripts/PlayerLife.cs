using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    AudioSource sfx;
    public GameObject golem;
    player player;
    GameObject healthBar;
    public int DamageTaken;
    public float health;
    float maxHealth = 0;
    float LoseHealth;
    float gainHealth;

    int heal = 1;

    public bool Invinci = false;
    public float InvinciTime = 1f;

   /* private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/

    private void Start()
    {
        maxHealth = health;

        sfx = GetComponent<AudioSource>();

        LoseHealth = 1 / (health / DamageTaken);

        gainHealth = 1 / (health / heal);
        
        healthBar = GameObject.FindGameObjectWithTag("PlayerHealth");

    }
  
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && Invinci ==false)
        {
            DecreaseHealth();  
            Invinci = true;
           
            if (health <= 0)
            {
                Die();
                gameObject.GetComponent<player>().Alive = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && Invinci == false)
        {
            DecreaseHealth();
            Invinci = true;

            if (health <= 0)
            {
                Die();
                gameObject.GetComponent<player>().Alive = false;
            }
        }
        if(other.gameObject.tag == "die")
        {
            Die();
        }
    }

    private void Update()
    {
        if (Invinci == true)
        {
            InvinciTime -= Time.deltaTime;
            if (InvinciTime <= 0)
            {
                Invinci = false;
                InvinciTime = 1f;
            }
        }

        if (health <= 0)
        {
            Die();
            gameObject.GetComponent<player>().Alive = false;
        }
    }

    //retunrs health;
    public float returnHealth()
    {
        return health;
    }
    //Health Decrease.
    void DecreaseHealth()
    {
        sfx.Play();
        health -= DamageTaken;
        healthBar.transform.localScale -= new Vector3(LoseHealth, 0f, 0f);
    }
    //Health Increase.
    public void increaseHealth(int i)
    {
        int n = 0;
        while (health < maxHealth && n < i)
        {
            health++;
            healthBar.transform.localScale += new Vector3(gainHealth, 0f, 0f);
            n++;
        }
    }
    //Destroy.
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Dead Scene");
        //player.GetComponent<player>().gotPot();
    }

}
