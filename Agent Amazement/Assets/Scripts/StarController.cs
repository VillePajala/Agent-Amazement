using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    // Setting up variables

    private AudioSource[] sounds = null;
    private GameObject screen = null;

	void Start () {

        // Finding gameobjects
        this.screen = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();

    } // Start
	
	void Update () {
		
	} // Update

    // If the star is being hit by a game object named Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            // Collision destroys the star
            Destroy(gameObject);
            // Collision plays the sound of poker chips falling
            this.sounds[3].Play();
            // The variable 'points' in ScoreCounter -script is being updated to increase the score
            this.screen.GetComponent<ScoreCounter>().points += 1;
        }

    } // OnTriggerEnter2D

}// Class
