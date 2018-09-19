using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    // Setting up variables

    public int health = 10;
    public int hits = 0;

    private GameObject screen = null;
    public GameObject explosion = null;
    private AudioSource[] sounds = null;

	void Start () {

        // Finding game objects
        this.screen = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();

	} // Start
	
	void Update () {
		
	} // Update

    // If a Trump is being hit by an object tagged as "Bullet"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // The variable hits is increased by 1 every time the bullet hits the Trump
            hits += 1;
        }

        // If total amount of bullet hits on Trump equals or is bigger than Trump's health
        if (hits >= health)
        {
            // The location of the Trump is saved
            Vector2 location = this.GetComponent<Transform>().position;
            // The explosion animation is palyed at the saved location
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            // The variable 'killcount' in ScoreCounter -script is being updated to increase the killscore
            this.screen.GetComponent<ScoreCounter>().killcount += 1;
            // The Trump is destroyed
            Destroy(gameObject);
            // Collision palyes the sound of the explosion
            this.sounds[1].Play();
            // The explosion Animation is destroyed
            Destroy(explode.gameObject, 1f);
        }

    } // OnCollisionEneter2D

} // Class
