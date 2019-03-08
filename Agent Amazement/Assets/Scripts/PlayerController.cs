using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject screen = null;

    Vector2 bulletPos;
    public float firerate = 0.5f;
    float nextfire = 0.0f;

    public int scoreamount = 0;
    public int killamount = 0;


    void Start () {
        this.Camera = GameObject.Find("Main Camera");
        this.sounds = GameObject.Find("SoundController").GetComponents<AudioSource>();
        this.screen = GameObject.Find("Screen");
        PlayerPrefs.DeleteAll();
    } 


    void LateUpdate () {

        // Player Movement
        if (Input.GetKey(KeyCode.S)) {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            bulletDirection = 0;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 0);

        } else if (Input.GetKeyUp(KeyCode.S)) {
            this.GetComponent<Animator>().enabled = false;

        } else if (Input.GetKey(KeyCode.D)) {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            bulletDirection = 1;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 1);

        } else if (Input.GetKeyUp(KeyCode.D)) {
            this.GetComponent<Animator>().enabled = false;

        } else if (Input.GetKey(KeyCode.W)) {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            bulletDirection = 2;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 2);

        } else if (Input.GetKeyUp(KeyCode.W)) {
            this.GetComponent<Animator>().enabled = false;

        } else if (Input.GetKey(KeyCode.A)) {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            bulletDirection = 3;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 3);

        } else if (Input.GetKeyUp(KeyCode.A)) {
            this.GetComponent<Animator>().enabled = false;
        }


        // Shooting
        if (Input.GetKeyDown(KeyCode.Return)) {
            speed = 0;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Shoot", 1);

        } else if (Input.GetKeyUp(KeyCode.Return)) {
            speed = 4f;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animator>().SetInteger("Shoot", 0);
            
        }

        if (Input.GetKey(KeyCode.Return) && Time.time > nextfire) {
            nextfire = Time.time + firerate;
            fire();
            this.sounds[2].Play(); 
        }
    } 


    
    void fire() {
        bulletPos = transform.position;

        if (bulletDirection == 1) {
            bulletPos += new Vector2(+0.75f, 0f);
            Instantiate(BulletToRight, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 3) {
            bulletPos += new Vector2(-0.75f, 0f);
            Instantiate(BulletToLeft, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 2) {
            bulletPos += new Vector2(+0.14f, +0.6f);
            Instantiate(BulletToUp, bulletPos, Quaternion.identity);
        } else if (bulletDirection == 0) {
            bulletPos += new Vector2(-0.14f, -0.9f);
            Instantiate(BulletToDown, bulletPos, Quaternion.identity);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "trump") {
            scoreamount = this.screen.GetComponent<ScoreCounter>().points;
            killamount = this.screen.GetComponent<ScoreCounter>().killcount;
            PlayerPrefs.SetInt("scoreamount", this.scoreamount);
            PlayerPrefs.SetInt("killamount", this.killamount);
            this.Camera.GetComponent<GameOver>().delay = 1;
            Vector2 location = this.GetComponent<Transform>().position;
            GameObject explode = (GameObject)Instantiate(this.explosion, location, Quaternion.identity);
            this.sounds[1].Play();
            this.sounds[7].Play();
            Destroy(gameObject);
            Destroy(explode.gameObject, 1f);
            this.Camera.GetComponent<CameraController>().enabled = false;
        }
    } 

    
} 


