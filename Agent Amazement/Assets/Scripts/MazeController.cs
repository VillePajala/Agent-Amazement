using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    // Setting up the variables
    private AudioSource[] sounds = null;

    void Start () {

        // Findig GameObjects
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
	} // Update


    // Everytime an enemy hits the walls of the maze, a bouncing sound is played
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trump")
        {
            // A bouncing sound is played
            this.sounds[4].Play();

        }

    } // OnCollisionEneter2D
}
