using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour {

    public int delay = 0;
	

	void Start () {
		
	} 
	
	
	void Update () {
        if ( delay == 1) {
            Invoke("GoToScene", 1);
        }	
	} 


    void GoToScene() {
        SceneManager.LoadScene(2);
    } 

} 
