using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float velX = 5f;
    public float velY = 5f;
    Rigidbody2D rb;


	void Start () {

        rb = GetComponent<Rigidbody2D>();

	} //Start
	

	void Update () {

        rb.velocity = new Vector2(velX, velY);

	} // Update


    // Destroy bullet when hitting any collider
    void OnCollisionEnter2D(Collision2D collision)
    {  

        Destroy(gameObject); 

    } // OnCollisionEnter2D


} // Class
