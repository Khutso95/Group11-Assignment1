using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyscore : MonoBehaviour
{
    public static keyscore instance;
    public TextMeshProUGUI text;
    int keynum;
     
    //initialise 
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    //changes UI key objects value from number to string and changes score.
   public void changeKeynum(int kval)
    {
        keynum += kval;
        text.text = "Key x" + keynum.ToString();
    }
}
