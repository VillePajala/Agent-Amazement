using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    // Setting up the variables

    // Speed of movement is set
    public float speed = 2.5f;
    // bulletDirection functions as trigger later on the code based on value
    float bulletDirection = 0;
    
    // Creating variables for bullets moving to different directions
    public GameObject BulletToRight;
    public GameObject BulletToLeft;
    public GameObject BulletToUp;
    public GameObject BulletToDown;

    public GameObject Camera = null;
    public GameObject explosion = null;
    private AudioSource[] sounds = null;
    public GameObject screen = null;

    Vector2 bulletPos;
    public float firerate = 0.5f;
    float nextfire = 0.0f;

    public int scoreamount = 0;
    public int killamount = 0;


    void Start () {

        // Findig GameObjects
        this.Camera = GameObject.Find("Main Camera");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.screen = GameObject.Find("Screen");
        PlayerPrefs.DeleteAll();

    } // Start


    void LateUpdate () {

        // Player movement and associated animations

        // Moving Player down with animation when associated key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            // Direction of the player movement
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            // Trigger variable for the bullets is set based on direction of the player movement
            bulletDirection = 0;
            // Animator is turned on
            this.GetComponent<Animator>().enabled = true;
            // Associated animation is enabled via build animator
            this.GetComponent<Animator>().SetInteger("Direction", 0);
        }

        else
        // When key is not pressed
        if (Input.GetKeyUp(KeyCode.S))
        {
            // Animator is turned off
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player right with animation when associated key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            // Direction of the player movement
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            // Trigger variable for the bullets is set based on direction of the player movement
            bulletDirection = 1;
            // Animator is turned on
            this.GetComponent<Animator>().enabled = true;
            // Associated animation is enabled via build animator
            this.GetComponent<Animator>().SetInteger("Direction", 1);
        }

        else
        // When key is not pressed
        if (Input.GetKeyUp(KeyCode.D))
        {
            // Animator is turned off
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player up with animation when associated key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Direction of the player movement 
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            // Trigger variable for the bullets is set based on direction of the player movement
            bulletDirection = 2;
            // Animator is turned on
            this.GetComponent<Animator>().enabled = true;
            // Associated animation is enabled via build animator
            this.GetComponent<Animator>().SetInteger("Direction", 2);
        }

        else
        // When key is not pressed
        if (Input.GetKeyUp(KeyCode.W))
        {
            // Animator is turned off
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player left with animation when associated key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Direction of the player movement
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            // Trigger variable for the bullets is set based on direction of the player movement
            bulletDirection = 3;
            // Animator is turned on
            this.GetComponent<Animator>().enabled = true;
            // Associated animation is enabled via build animator
            this.GetComponent<Animator>().SetInteger("Direction", 3);
        }

        else

        // When key is not pressed
        if (Input.GetKeyUp(KeyCode.A))
        {
            // Animator is turned off
            this.GetComponent<Animator>().enabled = false;
        }




        // Shooting and associated animations when the Enter Key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Player stops when shooting
            speed = 0;
            // Animator is turned on
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Shoot", 1);
        }

        else

        // Disabling shooting and assiciated animations when key is released
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // Player continues movement after shooting
            speed = 4f;
            // Animator is turned off
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animator>().SetInteger("Shoot", 0);
            
        }

        // Launginf the actual shooting and bullets if enter is pressed AND set time interval conditions are met
        if (Input.GetKey(KeyCode.Return) && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            fire();
            // The sound of a gun shot is played
            this.sounds[2].Play();
            
        }


    } // LateUpdate


    // Creating the right bullets when player shoots based on player's direction
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



    // Player dies if hit by an enemy

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a gameobject tagged as "trumop" hits the player
        if (collision.gameObject.tag == "trump")
        {
            // Getting the score count on time of player death
            scoreamount = this.screen.GetComponent<ScoreCounter>().points;
            // Getting the kill count on time of player death
            killamount = this.screen.GetComponent<ScoreCounter>().killcount;
            // Save score for another scene
            PlayerPrefs.SetInt("scoreamount", this.scoreamount);
            // Save kills for another scene
            PlayerPrefs.SetInt("killamount", this.killamount);
            // Collision sets the public int delay in GameOver -script to 1 which starts the process of scene change
            this.Camera.GetComponent<GameOver>().delay = 1;
            // the location of the player at the time of collision is saved
            Vector2 location = this.GetComponent<Transform>().position;
            // The explosion animation is played at the saved location
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            // Collision plays the sound of an explosion
            this.sounds[1].Play();
            // Collision plays the sound of an player moan
            this.sounds[7].Play();
            // Collision destroys the player
            Destroy(gameObject);
            // Collision destroys the explosion animation after 1 second delay
            Destroy(explode.gameObject, 1f);
            // Collision disabled the CameraController -script to avoid errors when the player object is being accessed even if it is been destroyed at this point
            this.Camera.GetComponent<CameraController>().enabled = false;
       

        }


    } // OnCollisionEneter2D

    

} // Class
