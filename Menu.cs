using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    public GameObject score;

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void play()
    {
        player.SetActive(true);
        UI.SetActive(false);
        score.SetActive(true);
        Time.timeScale = 1;
    }
    public void quit()
    {
        Application.Quit();
    }

    public void credits()
    {
        SceneManager.LoadScene(1);
    }

    public void rules()
    {
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
