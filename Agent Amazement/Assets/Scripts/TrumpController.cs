using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    public int health = 10;
    public int hits = 0;

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
            Destroy(gameObject);
        }
            

        

    } // OnCollisionEneter2D

} // Class
