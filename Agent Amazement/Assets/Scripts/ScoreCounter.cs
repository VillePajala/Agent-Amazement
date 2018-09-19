using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    // Setting up variables

    // Variables points and killcount are updated from other scripts
    public int points = 0;
    public int killcount = 0;

    GameObject scoretext = null;
    GameObject kills = null;

    public GameObject mastercoin = null;
	
	void Start () {

        // Finding gameobjects
        this.scoretext = GameObject.Find("ScoreText");
        this.kills = GameObject.Find("KillsText");
        this.mastercoin = GameObject.Find("MasterCoin");

	} // Start
	
	
	void Update () {

        // The UI scoreboard is updated acoording to "points" -variable's value
        this.scoretext.GetComponent<Text>().text = "Score: " + this.points + "/20";
        // The UI killscore is updated acoording to "killcount" -variable's value
        this.kills.GetComponent<Text>().text = "Kills: " + this.killcount + "/10";

        // if all stars have been collected and all the enemies killed
        if (points >= 20 && killcount >= 10)
        {
            
            // MasterCoin's layer order is changed so it is not hidden behind background
            this.mastercoin.GetComponent<Renderer>().sortingOrder = 3;
            // MasterCoin's collider is enabled so it can be collected
            this.mastercoin.GetComponent<BoxCollider2D>().enabled = true;
            // The kill count disappears after all the Trumps are destroyed so we need to print the final score in the end
            this.kills.GetComponent<Text>().text = "Kills: 10/10";

        }

	} // Update

} // Class
