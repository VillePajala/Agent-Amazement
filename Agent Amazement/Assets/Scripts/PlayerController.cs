using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2.5f;
    float bulletDirection = 0;

    public GameObject BulletToRight;
    public GameObject BulletToLeft;
    public GameObject BulletToUp;
    public GameObject BulletToDown;

    public GameObject Camera = null;

    public GameObject explosion = null;

    private AudioSource[] sounds = null;

    Vector2 bulletPos;
    public float firerate = 0.5f;
    float nextfire = 0.0f;


    void Start () {

        this.Camera = GameObject.Find("Main Camera");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
    } // Start


    void LateUpdate () {

        // Player movement and associated animations

        // Moving Player down with animation
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            bulletDirection = 0;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 0);
        }

        else

        if (Input.GetKeyUp(KeyCode.S))
        {
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player right with animation
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            bulletDirection = 1;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 1);
        }

        else

        if (Input.GetKeyUp(KeyCode.D))
        {
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player up with animation
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            bulletDirection = 2;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 2);
        }

        else

        if (Input.GetKeyUp(KeyCode.W))
        {
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player left with animation
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            bulletDirection = 3;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 3);
        }

        else

        if (Input.GetKeyUp(KeyCode.A))
        {
            this.GetComponent<Animator>().enabled = false;
        }




        // Enabling shooting animations
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Player stops when shooting
            speed = 0;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Shoot", 1);
        }

        else

        // Disabling shooting animations
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // Player continues movement after shooting
            speed = 4f;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animator>().SetInteger("Shoot", 0);
            
        }

        if (Input.GetKey(KeyCode.Return) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
            this.sounds[2].Play();
            
        }


    } // LateUpdate


    // Creating the right bullets when palyer shoots based on palyer's direction
    void fire()
    {
        bulletPos = transform.position;
        if (bulletDirection == 1)
        {
            bulletPos += new Vector2(+0.75f, 0f);
            Instantiate(BulletToRight, bulletPos, Quaternion.identity);
            
        } else if (bulletDirection == 3)
        {
            bulletPos += new Vector2(-0.75f, 0f);
            Instantiate(BulletToLeft, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 2)
        {
            bulletPos += new Vector2(+0.14f, +0.6f);
            Instantiate(BulletToUp, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 0)
        {
            bulletPos += new Vector2(-0.14f, -0.9f);
            Instantiate(BulletToDown, bulletPos, Quaternion.identity);
        } 
    } // Fire



    // Player dies if enemy is hit

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trump")
        {

            Vector2 location = this.GetComponent<Transform>().position;
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            this.sounds[1].Play();
            this.sounds[7].Play();
            Destroy(gameObject);
            Destroy(explode.gameObject, 1f);
            this.Camera.GetComponent<CameraController>().enabled = false;

        }


    } // OnCollisionEneter2D

} // Class
