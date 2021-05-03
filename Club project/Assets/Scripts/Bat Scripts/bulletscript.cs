using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float speed = 10.0f;
    Vector3 spawn;
    float x, y;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);

        spawn = transform.position;

        x = spawn.x - 1.0f;

        y = spawn.y + 1.4f;

        spawn = new Vector3(x, y, 0);

        transform.position = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);

        this.transform.localScale += new Vector3(0.025f, 0.025f, 0f);
    }
}