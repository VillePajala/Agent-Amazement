using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public GameObject agent = null;
    private AudioSource[] sounds = null;

    void Start() {
        this.agent = GameObject.Find("Player");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
    } 

    void Update () {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                this.agent.GetComponent<PlayerController>().enabled = false;
                this.sounds[0].Pause();
            } else {
                Time.timeScale = 1;
                this.agent.GetComponent<PlayerController>().enabled = true;
                this.sounds[0].Play();
            }
        } 
    } 

} 
