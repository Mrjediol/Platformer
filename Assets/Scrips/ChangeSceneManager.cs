using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager changeSceneManager;
    private float keyPressTime = 0f;
    private bool keyIsBeingHeld = false;


    private void Awake() => changeSceneManager = this;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            keyPressTime = Time.time;
            keyIsBeingHeld = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            keyIsBeingHeld = false;
            keyPressTime = 0f;
        }

        if (keyIsBeingHeld && Time.time - keyPressTime > 0.5f)
        {
            ReLoadScene();
            keyIsBeingHeld = false;
            keyPressTime = 0f;
        }
    }

    public void ChangeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
    public void ReLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ChoseScene(int scene)
    {
        SceneManager.LoadScene(scene - 1);
        Time.timeScale = 1;
    }
    public void ChooseSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    public void DeleteProgres()
    {
        PlayerPrefs.DeleteAll();
    }
}
