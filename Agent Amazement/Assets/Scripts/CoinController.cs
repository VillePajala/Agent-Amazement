using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    // Setting up variables

    public GameObject coin = null;
    private AudioSource[] sounds = null;
    public GameObject Camera = null;

    void Start () {

        // Finding gameobjects
        this.coin = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.Camera = GameObject.Find("Main Camera");

    } // Start
	
	
	void Update () {
		
	} // Update


    // When the MasterCoin is hit by player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Collision sets the public int win in LevelCleared -script to 1 which starts the process of scene change
            this.Camera.GetComponent<LevelCleared>().win = 1;
            // Collision disables ScoreCounter -script in game object "Screen"
            this.coin.GetComponent<ScoreCounter>().enabled = false;
            // Collision plays the sound of one person cheering
            this.sounds[5].Play();
            // Collision plays the sound of multiple people cheering
            this.sounds[6].Play();
            // Collision destroys the MasterCoin
            Destroy(gameObject);
            
        }

    } // OnCollisionEneter2D

} // Class
