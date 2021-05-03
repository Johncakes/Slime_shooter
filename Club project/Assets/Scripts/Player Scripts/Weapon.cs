using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletprefab;
    public float fireRate;
    float lastfired;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            if (Time.time - lastfired > 1 / fireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }

        void Shoot()
        {
            Instantiate(bulletprefab, firePoint.position, firePoint.rotation);
        }
    }
}