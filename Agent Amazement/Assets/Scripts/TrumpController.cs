using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

    public int health = 10;
    public int hits = 0;

    private GameObject screen = null;
    public GameObject explosion = null;
    private AudioSource[] sounds = null;

	void Start () {
        this.screen = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
	} 
	
	void Update () {
		
	} 

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            hits += 1;
        }

        if (hits >= health) {
            Vector2 location = this.GetComponent<Transform>().position;
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            this.screen.GetComponent<ScoreCounter>().killcount += 1;
            Destroy(gameObject);
            this.sounds[1].Play();
            Destroy(explode.gameObject, 1f);
        }
    }

} 


