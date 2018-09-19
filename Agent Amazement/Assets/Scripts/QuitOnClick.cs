using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

    // If the quit button is clicked on main menu
    public void Quit()
    {
        
        // Game stops if played as an application
        Application.Quit();

    } // Quit

} // Class
