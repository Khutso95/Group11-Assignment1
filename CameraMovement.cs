using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public float movespeed = 0.125f;
    public Vector3 offset;

    public bool GameisPaused;
    public GameObject pausemenu;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 3.5f, -5);

    }

    public void pause()
    {
        Time.timeScale = 0;
        GameisPaused = true;
        pausemenu.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        GameisPaused = false;
        pausemenu.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 lerpposition = Vector3.Lerp(transform.position, desiredposition, movespeed);
        transform.position = lerpposition;
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

    }
}
