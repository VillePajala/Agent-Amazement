using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("BulletToRight"))
        {
            Destroy(gameObject);
   
        }

        if (collision.name.Equals("BulletToLeft"))
        {
            Destroy(gameObject);

        }

        if (collision.name.Equals("BulletToDown"))
        {
            Destroy(gameObject);

        }

        if (collision.name.Equals("BulletToUp"))
        {
            Destroy(gameObject);

        }
    }
}
