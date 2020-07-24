using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    //images to set active as the player picks up coins
    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject Coin4;

    
    

    

    public void pickedcoinup()
    {
       //i created a variable in the other script as it was easier to keep track of coins picked up
        if (FindObjectOfType<Playercontroller>().coinspickedup == 1)
        {
            Coin1.SetActive(true);
        }

        if (FindObjectOfType<Playercontroller>().coinspickedup == 2)
        {
            Coin2.SetActive(true);
        }

        if (FindObjectOfType<Playercontroller>().coinspickedup == 3)
        {
            Coin3.SetActive(true);
        }

        if (FindObjectOfType<Playercontroller>().coinspickedup == 4)
        {
            Coin1.SetActive(true);
        }
    }

    
    //detect when the player walks into the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Playercontroller>().coinspickedup += 1;
            pickedcoinup();
            
        }
    }

   }
