using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneManager : MonoBehaviour
{
    public static ChangeSceneManager changeSceneManager;


    private void Awake() => changeSceneManager = this;

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
