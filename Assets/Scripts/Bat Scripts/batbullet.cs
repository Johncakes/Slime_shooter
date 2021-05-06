using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batbullet : MonoBehaviour
{

    float X = 12.0f;
    float Y;

    // Start is called before the first frame update
    void Start()
    {
        Y = Random.Range(4.5f, -4.0f);

        transform.position = new Vector3(X, Y, 0f);

        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(18.0f * Time.deltaTime, 0, 0);
    }
}