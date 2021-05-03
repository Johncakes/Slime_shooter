using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player" && hitInfo.tag != "Bullet")
        {
            //Debug.Log(hitInfo.tag);

            if (hitInfo.tag != "potion")
            {

            Destroy(gameObject);
            }

        }

    }

}
