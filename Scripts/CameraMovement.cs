using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float movespeed = 0.125f;
    public Vector3 offset;

    public bool GameisPaused;
    public GameObject pausemenu;

    public Text timertext;
    public float timer;
    public static float fastesttime = 100;
    public Text fastesttimetext;
    public float timetaken;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 2, -5);
        Cursor.visible = true;
        timer = 0;
        Time.timeScale = 0;
        recordfastesttime();
    }

    public void pause()
    {
        Time.timeScale = 0;
        GameisPaused = true;
        pausemenu.SetActive(true);
        Cursor.visible = true;
    }

    public void resume()
    {
        Time.timeScale = 1;
        GameisPaused = false;
        pausemenu.SetActive(false);
        Cursor.visible = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 lerpposition = Vector3.Lerp(transform.position, desiredposition, movespeed);
        transform.position = lerpposition;
    }

    //added this function because the fastest time was not being recorded properly
    public void recordfastesttime()
    {
        fastesttimetext.text = "Fastest Time : " + PlayerPrefs.GetFloat("FastestTime").ToString("0");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        //this create and show timer on screen
        timer += Time.deltaTime;
        timertext.text = timer.ToString("0");

        timetaken = timer;

        if (FindObjectOfType<Playercontroller>().gamefinished && timetaken < fastesttime)
        {
            fastesttime = timetaken;
            PlayerPrefs.SetFloat("FastestTime", fastesttime);
            recordfastesttime();
        }

        
    }
}
