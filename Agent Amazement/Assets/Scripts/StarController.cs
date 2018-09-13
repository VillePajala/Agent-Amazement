using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private GameObject screen = null;

	// Use this for initialization
	void Start () {

        this.screen = GameObject.Find("Screen");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            Destroy(gameObject);
            this.screen.GetComponent<ScoreCounter>().points += 1;
        }
    }
}
