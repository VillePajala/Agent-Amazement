using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    private AudioSource[] sounds = null;


    void Start () {
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
    } 
	
	void Update () {
		
	} 

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "trump") {
            this.sounds[4].Play();
        }
    } 
    
}
