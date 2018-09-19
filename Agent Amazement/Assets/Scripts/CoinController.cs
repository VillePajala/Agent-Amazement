using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    // Setting up variables

    public GameObject coin = null;
    private AudioSource[] sounds = null;
    public GameObject Camera = null;
    public GameObject screen = null;

    public int score = 0;
    public int kills = 0;

    void Start () {

        // Finding gameobjects
        this.coin = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.Camera = GameObject.Find("Main Camera");
        this.screen = GameObject.Find("Screen");

    } // Start
	
	
	void Update () {
		
	} // Update


    // When the MasterCoin is hit by player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Getting the score count on time of player collecting the MasterCoin
            score = this.screen.GetComponent<ScoreCounter>().points;
            // Getting the kill count on time of player collecting the MasterCoi
            kills = this.screen.GetComponent<ScoreCounter>().killcount;
            // Save score for another scene
            PlayerPrefs.SetInt("score", this.score);
            // Save kills for another scene
            PlayerPrefs.SetInt("kills", this.kills);
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
