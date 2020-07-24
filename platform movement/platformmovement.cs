using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour
{
    //all variables used
    public float speed = 3f;
    bool moveR = true;
    //max distance the object can move variables
    public float Rmaxmove=4f;
    public float Lmaxmove = -4f;



    //use update to make platform move
    void Update()
    {
        //will start to move left when rmaxmove is reached
        if (transform.position.x > Rmaxmove)
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
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
