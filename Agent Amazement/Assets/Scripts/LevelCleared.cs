using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCleared : MonoBehaviour
{
    // Setting up a variable which functions as a trigger
    public int win = 0;

    void Start()
    {

    } // Start


    void Update()
    {
        // In case the Player collides wtih the MasterCoin, the variable win is changed to 1 from the CoinController -script
        if (win == 1)
        {
            // folloving function is delayed to start after 2 seconds
            Invoke("GoToScene", 2);
        }


    } // Update

    // The Level CLeared -scene is loaded
    void GoToScene()
    {
        SceneManager.LoadScene(3);

    } // GoToScene

} // Class
