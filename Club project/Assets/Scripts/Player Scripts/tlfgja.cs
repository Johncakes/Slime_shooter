using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlfgja : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Rigidbody2D.velocity.y >= 0 && (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.X)))
        {
            m_Rigidbody2D.velocity = m_Rigidbody2D.velocity * 0.5f;
        }
    }
}
