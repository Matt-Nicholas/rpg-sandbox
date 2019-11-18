using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    Vector3 spawnPosition;

    private void Start()
    {
        Range = 20f;
        Damage = 4;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 50f);
    }

    private void Update()
    {
        if(Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
            Extinguish();
        }

        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.transform.tag == "Enemy")
    //    {
    //        collision.transform.GetComponent<IEnemy>().TakeDamage(Damage);
    //    }

    //    Extinguish();
    //}

    void Extinguish()
    {
        Destroy(gameObject);
    }
}
