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
    public GameObject endgamebuttons;

    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void play()
    {

        UI.SetActive(false);
        score.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
        endgamebuttons.SetActive(false);
        score.SetActive(false);
        UI.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    public void quit()
    {
        Application.Quit();
    }

    public void credits()
    {
        SceneManager.LoadScene(2);
    }

    public void rules()
    {
        SceneManager.LoadScene(1);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
