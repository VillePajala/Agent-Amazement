using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCleared : MonoBehaviour {

    public int win = 0;


    void Start() {

    }

    void Update() {
        if (win == 1) {
            Invoke("GoToScene", 2);
        }
    } 

    void GoToScene() {
        SceneManager.LoadScene(3);
    } 

} 
