using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public int points = 0;
    GameObject scoretext = null;
	
	void Start () {

        this.scoretext = GameObject.Find("ScoreText");

	} // Start
	
	
	void Update () {

        this.scoretext.GetComponent<Text>().text = "Score: " + this.points;

	} // Update
} // Class
