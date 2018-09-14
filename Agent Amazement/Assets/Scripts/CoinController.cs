using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public GameObject coin = null;
	
	void Start () {

        this.coin = GameObject.Find("Screen");

	} // Start
	
	
	void Update () {
		
	} // Update


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.coin.GetComponent<ScoreCounter>().enabled = false;
            Destroy(gameObject);
        }


    } // OnCollisionEneter2D

} // Class
