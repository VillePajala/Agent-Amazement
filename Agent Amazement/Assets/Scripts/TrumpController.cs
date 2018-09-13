﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    public int health = 10;
    public int hits = 0;

    public GameObject explosion = null;

	void Start () {
		
	} // Start
	
	void Update () {
		
	} // Update

    // Trump dies if hit by a bullet enough times 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hits += 1;
        }

        if (hits >= health)
        {
            Vector2 location = this.GetComponent<Transform>().position;
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explode.gameObject, 1f);
        }
            

        

    } // OnCollisionEneter2D

} // Class
