using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserDetector : MonoBehaviour
{

    public GameObject loserdetector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (FindObjectOfType<Playercontroller>().coinspickedup < 5)
            {
                loserdetector.SetActive(true);
            }
        
        
    }
}
