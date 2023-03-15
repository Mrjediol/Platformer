using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager changeSceneManager;



    public Slider mySlider;
    public float holdDuration = 0.5f;

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
            mySlider.value = 0f;
        }

        if (keyIsBeingHeld && Time.time - keyPressTime > holdDuration)
        {
            float progress = Mathf.Clamp01((Time.time - keyPressTime - holdDuration) / (1f - holdDuration));
            mySlider.value = progress;

            if (progress == 1f)
            {
                ReLoadScene();
                keyIsBeingHeld = false;
                keyPressTime = 0f;
                mySlider.value = 0f;
            }
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
