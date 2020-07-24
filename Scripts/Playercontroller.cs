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

    public GameObject fastesttime;
    

    public bool isgrounded=false;
    Transform playertrans;
    Transform GroundTag;
    public LayerMask Playermask;

    private bool rightleft=true;
    Rigidbody2D rb;

    //added variables
    public BoxCollider2D groundcheckbox;
    public int coinspickedup = 0;
    public GameObject wintext;

    public bool gamefinished;

    public int spacepresscounter = 0;
    //initialize
    void Start()
    {
        //gets the rigid body and transform components
        rb = this.GetComponent<Rigidbody2D>();
        playertrans = this.transform;
        gamefinished = false;
        //GroundTag = GameObject.Find(this.name + "/ground").transform;
    }

    //use fixed update for movement controls
    void FixedUpdate()
    {
        //check if grounded
        //removed because i didnt know how to use it
        //isgrounded = Physics2D.Linecast(playertrans.position, GroundTag.position, Playermask);

        //get movement axis
        move = Input.GetAxisRaw("Horizontal");

        //apply movements values to the object 
        rb.velocity = new Vector2(move*speed,rb.velocity.y);

             
        //this is used to turn the player 180 degrees for walking back and forth 
        if (rightleft==false&&move>0)
        {
            flip();
        }
        else if (rightleft==true&&move<0)
        {
            flip();
        }

        if(playertrans.position.y < -4)
        {
            Die();
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
    void Die()
    {
        
            SceneManager.LoadScene(sceneBuildIndex:0);
    }
    //to show when the player wins
    public void wingame()
    {
        if (coinspickedup == 6)
        {
            wintext.SetActive(true);
            Time.timeScale = 0;
            gamefinished = true;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isgrounded = true;
            
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            playertrans.transform.parent = collision.transform;
            isgrounded = true;
        }
    }

    
    //i was having issues with detecting when the player is still on the floor when moving so i added this function
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isgrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isgrounded = false;
        }

        if (collision.gameObject.tag == "MovingPlatform")
        {
            this.transform.parent = null;
            isgrounded = false;
        }
    }

    //when player comes into contact with the key game object, destory game object 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            
        }
    }


    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            spacepresscounter += 1;
            if (isgrounded == true)
            {
                rb.velocity += Vector2.up * jumpf;

                Debug.Log(spacepresscounter);
            }

        }
        
        wingame();
        if (gamefinished)
        {
            //Time.timeScale = 0;
            fastesttime.SetActive(true);
            Cursor.visible = true;
        }

        
    }
}
