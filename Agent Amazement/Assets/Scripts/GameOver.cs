using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {

    // Setting up a variable which functions as a trigger
    public int delay = 0;
	
	void Start () {
		
	} // Start
	
	
	void Update () {

        // In case the Player is hit by an enemy, the variable delay is changed to 1 from the PlayerController -script
        if ( delay == 1)
        {
            // folloving function is delayed to start after 1 second
            Invoke("GoToScene", 1);
        }

		
	} // Update


    // The Game Over -scene is loaded
    void GoToScene()
    {
        SceneManager.LoadScene(2);

    } // GoToScene

} // Class
