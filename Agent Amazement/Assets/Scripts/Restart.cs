using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    void Update()
    {
        // If the key 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            // The currently active scene is reloaded
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } // if

    } // Update

} // Class