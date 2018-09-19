using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    // Setting up the variables
    public GameObject agent = null;
    private AudioSource[] sounds = null;

    void Start()
    {
        // Findig GameObjects
        this.agent = GameObject.Find("Player");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();

    } // Start

    void Update () {

        // If the key 'P' is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // If game time is normal while P is pressed
            if (Time.timeScale == 1)
            {
                // game time is stopped
                Time.timeScale = 0;
                // The script for player movement is disabled
                this.agent.GetComponent<PlayerController>().enabled = false;
                // Background music is paused
                this.sounds[0].Pause();
            }

            // When P is not pressed or pressed again
            else
            {
                // Game time is set to normal
                Time.timeScale = 1;
                // The script for player movement is enabled
                this.agent.GetComponent<PlayerController>().enabled = true;
                // Background music plays normally
                this.sounds[0].Play();
            }

        } // if

    } // Update
} // Class
