﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject coin = null;
    private AudioSource[] sounds = null;

    void Start () {

        this.coin = GameObject.Find("Screen");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();

    } // Start
	
	
	void Update () {
		
	} // Update


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.coin.GetComponent<ScoreCounter>().enabled = false;
            this.sounds[5].Play();
            this.sounds[6].Play();
            Destroy(gameObject);
        }


    } // OnCollisionEneter2D

} // Class
