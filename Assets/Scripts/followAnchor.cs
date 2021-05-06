using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAnchor : MonoBehaviour
{

    public Transform follow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = follow.transform.position;
    }
}
