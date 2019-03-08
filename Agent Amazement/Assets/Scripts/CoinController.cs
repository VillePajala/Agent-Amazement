using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject coin = null;
    private AudioSource[] sounds = null;
    public GameObject Camera = null;
    public GameObject screen = null;

    public int score = 0;
    public int kills = 0;


    void Start () {
        this.coin = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.Camera = GameObject.Find("Main Camera");
        this.screen = GameObject.Find("Screen");
    } 
	
	
	void Update () {
		
	} 

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.name == "Player") {
            score = this.screen.GetComponent<ScoreCounter>().points;
            kills = this.screen.GetComponent<ScoreCounter>().killcount;
            PlayerPrefs.SetInt("score", this.score);
            PlayerPrefs.SetInt("kills", this.kills);
            this.Camera.GetComponent<LevelCleared>().win = 1;
            this.coin.GetComponent<ScoreCounter>().enabled = false;
            this.sounds[5].Play();
            this.sounds[6].Play();
            Destroy(gameObject);
        }
    } 

}
