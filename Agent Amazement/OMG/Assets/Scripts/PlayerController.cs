using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1.5f;

    float bulletDirection = 0;

    //public Transform firePoint;
    //public GameObject Bullet;

    public GameObject BulletToRight;
    public GameObject BulletToLeft;
    public GameObject BulletToUp;
    public GameObject BulletToDown;
    Vector2 bulletPos;
    public float firerate = 0.5f;
    float nextfire = 0.0f;



    void Start () {

        

    }


    void Update () {

        
        

        // Moving Player down
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            bulletDirection = 0;
        }


        // Moving Player right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            bulletDirection = 1;
        }

        // Moving Player up
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            bulletDirection = 2;
        }

        // Moving Player left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            bulletDirection = 3;
        }




        
        // Palayer animation walking up
        if (Input.GetKeyDown(KeyCode.W))
        {  
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 2);
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
           this.GetComponent<Animator>().enabled = false;
        }
        


        // Palayer animation walkign down
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            this.GetComponent<Animator>().enabled = false;
        }

        // Palayer animation walking right
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            this.GetComponent<Animator>().enabled = false;
        }

        // Palayer animation walking left
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 3);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.GetComponent<Animator>().enabled = false;
        }


        // Enabling shooting animations

        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Shoot", 1);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animator>().SetInteger("Shoot", 0);
            
        }

        if (Input.GetKeyDown(KeyCode.Return) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
        }


    }

 

    void fire()
    {
        bulletPos = transform.position;
        if (bulletDirection == 1)
        {
            bulletPos += new Vector2(+1f, 0f);
            Instantiate(BulletToRight, bulletPos, Quaternion.identity);
            
        } else if (bulletDirection == 3)
        {
            bulletPos += new Vector2(-1f, 0f);
            Instantiate(BulletToLeft, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 2)
        {
            bulletPos += new Vector2(0f, +1f);
            Instantiate(BulletToUp, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 0)
        {
            bulletPos += new Vector2(0f, -1f);
            Instantiate(BulletToDown, bulletPos, Quaternion.identity);
        } 
    }

}
