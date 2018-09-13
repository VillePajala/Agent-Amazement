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


    void LateUpdate () {

        
        

        // Moving Player down
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
            // this.transform.Translate(Vector2.down * 0 * Time.deltaTime);
            // bulletDirection = 0;
            // this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player right
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            bulletDirection = 1;
            // this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 1);
        }

        else

        if (Input.GetKeyUp(KeyCode.D))
        {
            // this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            // bulletDirection = 1;
            // this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player up
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            bulletDirection = 2;
            // this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-3);
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 2);
        }

        else

        if (Input.GetKeyUp(KeyCode.W))
        {
            // this.transform.Translate(Vector2.up * speed * Time.deltaTime);
            // bulletDirection = 2;
            // this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<Animator>().enabled = false;
        }

        else

        // Moving Player left
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            bulletDirection = 3;
            //this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Direction", 3);
        }

        else

        if (Input.GetKeyUp(KeyCode.A))
        {
            // this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            // bulletDirection = 3;
            //this.Maze.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            this.GetComponent<Animator>().enabled = false;
        }

   
        


        // Enabling shooting animations

        if (Input.GetKeyDown(KeyCode.Return))
        {
            speed = 0;
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("Shoot", 1);
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            speed = 1.5f;
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Animator>().SetInteger("Shoot", 0);
            
        }

        if (Input.GetKey(KeyCode.Return) && Time.time > nextfire)
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
    }

}
