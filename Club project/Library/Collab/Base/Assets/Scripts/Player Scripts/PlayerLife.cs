using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject golem;
    GameObject healthBar;
    public int DamageTaken;
    public float health;
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

    private void Update()
    {
        if (Invinci == true)
        {
            InvinciTime -= Time.deltaTime;
            if (InvinciTime <= 0)
            {
                Invinci = false;
                InvinciTime = 0.8f;
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
        health -= DamageTaken;
        healthBar.transform.localScale -= new Vector3(LoseHealth, 0f, 0f);
    }
    //Health Increase.
    public void increaseHealth()
    {
        health++;
        healthBar.transform.localScale += new Vector3(gainHealth, 0f, 0f);
    }
    //Destroy.
    public void Die()
    {
        Destroy(gameObject);
    }

}
