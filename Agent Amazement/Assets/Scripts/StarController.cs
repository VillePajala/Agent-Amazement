using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private GameObject screen = null;

	void Start () {

        this.screen = GameObject.Find("Screen");

	} // Start
	
	void Update () {
		
	} // Update

    // If the player hits the star, star is destroyed and player gains 1 point
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Destroy(gameObject);
            this.screen.GetComponent<ScoreCounter>().points += 1;
        }
    } // OnTriggerEnter2D

}// Class
