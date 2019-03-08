using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    private AudioSource[] sounds = null;
    GameObject audiolistener = null;
    

    void Start() {
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.audiolistener = GameObject.Find("Main Camera");
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.M)) {
            if (this.sounds[0].isPlaying) {
                this.sounds[0].Pause();
            } else {
                this.sounds[0].Play();
            } 
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            if (AudioListener.volume == 0f) {
                AudioListener.volume = 1f;
            } else {
                AudioListener.volume = 0f;
            }
        }
    }


}



