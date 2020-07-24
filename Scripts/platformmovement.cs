using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour
{
    //all variables used
    float directiononX;
    public float speed = 3f;
    bool moveR = true;
    //max distance the object can move variables
    public float Rmaxmove=4f;
    public float Lmaxmove = -4f;
    public GameObject platform;

    private void Start()
    {
        platform = this.gameObject;
        Rmaxmove = platform.transform.position.x + Rmaxmove;
        Lmaxmove = platform.transform.position.x + Lmaxmove;
    }

    //use update to make platform move
    void Update()
    {
        //will start to move left when rmaxmove is reached
        if (platform.transform.position.x > Rmaxmove)
        {
            moveR = false;
        }
         
        //will move right when lmaxmove is reached, must be negative
        if(transform.position.x<Lmaxmove)
        {
            moveR = true;
        }

        //this applies movement to the gameobject connected using transform.position
        if(moveR)
        {
            platform.transform.position = new Vector2(platform.transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            platform.transform.position = new Vector2(platform.transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
