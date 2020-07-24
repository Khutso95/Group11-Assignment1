using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    //set key value to 1 for UI 
    public int kval = 1;

    //on trigger enter for player game object, only the player can pick the key up
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            keyscore.instance.changeKeynum(kval);
        }
    }
}
