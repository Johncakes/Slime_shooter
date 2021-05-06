using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golem : MonoBehaviour
{
    Transform target;

    //public GameObject player;
    public Rigidbody2D rb;

    //Bool
    bool facingRight = true;
    bool dashwarning = false;
    //bool isPlayerDead = false;

    //float
    public float speed;
    public float dashSpeed;
    public float patternTime;
    public float patternRestTime;
    public float dashWarningTime = 0.45f;
    public float resetDashWarningTime;
    public float delayAfterSkill = 0;
    float fallTime = 0f;
    float targetXLocation = 0f;

    //int
    int patternType = 0;
    public int playerTakeDamage;
    public int golemJump;
    public int golemsmash;

    //class
    Bullet dmg;
    public SpriteRenderer sr;

    //Color stuff.
    Color m_Color;


    //start
    void Start()
    {


        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        Random.Range(3,9);
        
    }



    void Update()
    {
        // X position of the target.
        if (target != null)
        {
            targetXLocation = target.transform.position.x; //Debug.Log(targetXLocation);
        }

        

        if (delayAfterSkill >= 0)
        {
                delayAfterSkill -= Time.fixedDeltaTime;

        }



        //Flipping golem's poistion.
        Flip();

        //Time for pattern.
        patternTime -= Time.deltaTime;

        //pattern time.
        if (patternTime < 0)
        {
            patternType = Random.Range(1, 3);
            patternTime = Random.Range(3,9);
            
            //Debug.Log("patterntype :" + patternType);
            //Debug.Log("pattern time = " + patternTime);

            if (patternType == 1)
            {
                dashwarning = true;
                sr.color = Color.yellow;
            }
            else if (patternType == 2)
            {
                dashwarning = true;
                sr.color = Color.red;
            }
        }

        //CoolDown.

        if (dashwarning == true)
        {
            dashWarningTime -= Time.deltaTime;
            //Debug.Log("Doing Cooldown :" + cooldown);

            if (dashWarningTime <= 0 && patternType == 1)
            {
                //Debug.Log("doing Rush");
                sr.color = Color.white;
                Rush();

            }
            else if (dashWarningTime <= 0)
            {
               
                sr.color = Color.white;
                Slam();
                fallTime += Time.deltaTime;
                
                
            }
        }

   
        
        //Movement;
       if (target != null && delayAfterSkill <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        }

    }

    // Bullet Detection;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            //Debug.Log("Hit");
            
            gameObject.GetComponent<GolemHealth>().Takedamage(1);

            Destroy(other.gameObject);
        }

    }

 

    //Slam pattern.
    void Slam()
    {
        if (fallTime <= 0.1f)
        {
            rb.AddForce(new Vector2(0f, golemJump));
        }

        if(fallTime > 1)
        {
            transform.position = new Vector2(targetXLocation, transform.position.y);
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0f, golemsmash));
            dashwarning = false;
            dashWarningTime = resetDashWarningTime;
            delayAfterSkill = 2.7f;
            fallTime = 0;
        }
        
    }

    //Rush pattern.
    void Rush()
    {
        //Debug.Log("running Rush");
        rb.velocity = transform.right * dashSpeed;
        dashwarning = false;
        dashWarningTime = resetDashWarningTime;

    }




    //Player position checker.
    public void Looking(bool n)
    {
        if (n == true)
        {
            facingRight = true;
        }
        else if (n == false)
        {
            facingRight = false;
        }
 

    }

    //Fliping Golem's location.
    void Flip()
    {
        if (facingRight == false)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        else
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }


   

}


