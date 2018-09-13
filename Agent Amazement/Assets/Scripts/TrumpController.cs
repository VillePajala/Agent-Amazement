using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

	void Start () {
		
	} // Start
	
	void Update () {
		
	} // Update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject, 2f);
            // Player Dies
   
        }

        else
        {
            Destroy(gameObject);
        }
       

        
    } // OnCollisionEneter2D
} // Class
