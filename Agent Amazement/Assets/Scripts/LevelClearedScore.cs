using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelClearedScore : MonoBehaviour {


    void Start() {
        int points = PlayerPrefs.GetInt("score");
        int killcount = PlayerPrefs.GetInt("kills");
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE:  " + points + " /20";
        GameObject.Find("Kills").GetComponent<Text>().text = "KILLS:  " + killcount + " /10";
    } 


    void Update() {

    } 

} 
