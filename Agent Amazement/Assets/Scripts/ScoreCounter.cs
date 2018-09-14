using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public int points = 0;
    public int killcount = 0;
    GameObject scoretext = null;
    GameObject kills = null;

    public GameObject mastercoin = null;
	
	void Start () {

        this.scoretext = GameObject.Find("ScoreText");
        this.kills = GameObject.Find("KillsText");
        this.mastercoin = GameObject.Find("MasterCoin");

	} // Start
	
	
	void Update () {

        this.scoretext.GetComponent<Text>().text = "Score: " + this.points + "/20";
        this.kills.GetComponent<Text>().text = "Kills: " + this.killcount + "/10";


        if (points >= 20 && killcount >= 10)
        {
            this.mastercoin.GetComponent<Renderer>().sortingOrder = 3;
      
        }


	} // Update
} // Class
