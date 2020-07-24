using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour
{
    //set values that will be used.
    public float speed=10f;
    public float jumpf=10f;
    public float move;

    public int health = 3;
    

    public bool isgrounded=false;
    Transform playertrans;
    Transform GroundTag;
    public LayerMask Playermask;

    private bool rightleft=true;
    Rigidbody2D rb;

    //initialize
    void Start()
    {
        //gets the rigid body and transform components
        rb = this.GetComponent<Rigidbody2D>();
        playertrans = this.transform;
        GroundTag = GameObject.Find(this.name + "/ground").transform;
    }

    //use fixed update for movement controls
    void FixedUpdate()
    {
        //check if grounded
        isgrounded = Physics2D.Linecast(playertrans.position, GroundTag.position, Playermask);

        //get movement axis
        move = Input.GetAxisRaw("Horizontal");

        //apply movements values to the object 
        rb.velocity = new Vector2(move*speed,rb.velocity.y);

        //run jump function if space is pushed 
        if(Input.GetKeyDown(KeyCode.Space))
            jump();
        
        //this is used to turn the player 180 degrees for walking back and forth 
        if (rightleft==false&&move>0)
        {
            flip();
        }
        else if (rightleft==true&&move<0)
        {
            flip();
        }
    }

    //jump function
    void jump()
    {
       
        
            rb.velocity += Vector2.up * jumpf;
        
    }

    //flip function flips palyer game object 180 degrees
    void flip()
    {
        rightleft = !rightleft;
        Vector3 Scaler = transform.localScale;
        //sets object orientation to the reverse of what it is, this flips the game object
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    //health script 
    void Hurt()
    {
        health--;
        if (health <= 0)
            SceneManager.LoadScene(sceneBuildIndex:1);
    }

    //for detecting collision with enemy game object and runs hurt function if in contact with the enemy 
     void OnCollisionEnter2D(Collision2D collision)
    {
        enemymove badguy = collision.collider.GetComponent<enemymove>();
        if(badguy!=null)
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                if(point.normal.y >=0.9f)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpf;
                    rb.velocity = velocity;
                    badguy.Hurt();
                }
                else
                {
                    Hurt();
                }
            }

            


        }

    }

    //when player comes into contact with the key game object, destory game object 
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("key"))
        {
            Destroy(other.gameObject);
        }
    }
}
