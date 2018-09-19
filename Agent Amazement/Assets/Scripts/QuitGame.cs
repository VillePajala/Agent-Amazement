using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	
	
	void Update () {

        // If the ESC key is pressed
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // Game stops if played in editor
            UnityEditor.EditorApplication.isPlaying = false;
            // Game stops if played as an application
            Application.Quit();
        }
		
	} // Update
} // Class
