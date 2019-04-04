﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;

	// Use this for initialization
	void Start ()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Destroy(hitInfo.gameObject);
            Score.score += 10;
        }
        else if (hitInfo.gameObject.tag == "Spell")
        {
            Destroy(hitInfo.gameObject);
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
