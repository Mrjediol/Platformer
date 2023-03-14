using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pauseMenuUi;
    private bool GameIsPause;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {

        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        AudioManager.audioManager.Play("OpenMenu");
    }
    public void Resume()
    {
       
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        AudioManager.audioManager.Play("CloseMenu");
    }

}
