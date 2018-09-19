using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

	
	void Start () {
        int points = PlayerPrefs.GetInt("scoreamount");
        int killcount = PlayerPrefs.GetInt("killamount");
        GameObject.Find("Score").GetComponent<Text>().text = "SCORE:  " + points + " /20";
        GameObject.Find("Kills").GetComponent<Text>().text = "KILLS:  " + killcount + " /10";
    } // Start
	
	
	void Update () {
		
	} // Update
} // Class
