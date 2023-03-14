using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
public class FinishLevel : MonoBehaviour
{

    OddsBars oddsBars;

    public TextMeshProUGUI chanceOfStars;

    public TextMeshProUGUI YouObtainedStars;

    public Image oneStarImg;

    public Image twoStarsImg;

    public Image treeStarsImg;

    public float levelNumber;

    public GameObject levelFinishScreem;
    private void Start()
    {
        oddsBars = FindObjectOfType<OddsBars>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomNum = UnityEngine.Random.Range(1, 101);
            Debug.Log(randomNum);
            if (randomNum <= oddsBars.currentValue)
            {
                CompleteLevel();
            }
            else
            {
                FailLevel(randomNum);
            }
        }
    }

    private void FailLevel(int n)
    {
        ChangeSceneManager changeSceneManager = FindObjectOfType<ChangeSceneManager>();
        changeSceneManager.ReLoadScene();
    }

    private void CompleteLevel()
    {

        int numStars = GetStars(oddsBars.treeStarsChance, oddsBars.twoStarsChance, oddsBars.oneStarsChance);

        // Guardar el número de estrellas en PlayerPrefs
        string key = "level" + levelNumber + "Stars";
        int starsRecord = PlayerPrefs.GetInt(key, 0);
        if (starsRecord < numStars)
        {
            PlayerPrefs.SetInt(key, numStars);
            PlayerPrefs.Save();

        }


        levelFinishScreem.SetActive(true);
        Time.timeScale = 0f;
        if (numStars == 3)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.white;
            treeStarsImg.color = Color.white;
            AudioManager.audioManager.Play("3Star");
        }
        else if (numStars == 2)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.white;
            treeStarsImg.color = Color.black;
            AudioManager.audioManager.Play("2Star");
        }
        else if (numStars == 1)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.black;
            treeStarsImg.color = Color.black;
            AudioManager.audioManager.Play("1Star");
        }
    }

    private int GetStars(float treeStars, float twoStars, float oneStar)
    {
        float totalChance = treeStars + twoStars + oneStar;
        float randomNumber = UnityEngine.Random.Range(0, totalChance);

        if (randomNumber < treeStars)
        {
            return 3;
        }
        else if (randomNumber < treeStars + twoStars)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    //private int[] NumberOfStars()
    //{

    //    if (oddsBars.currentValue >= 100f)
    //    {
    //        stars[0] = 100;
    //        stars[1] = 0;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 95f)
    //    {
    //        stars[0] = 90;
    //        stars[1] = 10;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 90f)
    //    {
    //        stars[0] = 80;
    //        stars[1] = 20;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 85f)
    //    {
    //        stars[0] = 70;
    //        stars[1] = 30;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 80f)
    //    {
    //        stars[0] = 60;
    //        stars[1] = 40;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 75f)
    //    {
    //        stars[0] = 50;
    //        stars[1] = 50;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 70f)
    //    {
    //        stars[0] = 40;
    //        stars[1] = 60;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 65f)
    //    {
    //        stars[0] = 30;
    //        stars[1] = 70;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 60f)
    //    {
    //        stars[0] = 20;
    //        stars[1] = 80;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 55f)
    //    {
    //        stars[0] = 10;
    //        stars[1] = 90;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 50f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 95;
    //        stars[2] = 0;
    //    }
    //    else if (oddsBars.currentValue >= 45f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 85;
    //        stars[2] = 10;
    //    }
    //    else if (oddsBars.currentValue >= 40f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 75;
    //        stars[2] = 20;
    //    }
    //    else if (oddsBars.currentValue >= 35f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 65;
    //        stars[2] = 30;
    //    }
    //    else if (oddsBars.currentValue >= 30f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 55;
    //        stars[2] = 40;
    //    }
    //    else if (oddsBars.currentValue >= 25f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 45;
    //        stars[2] = 50;
    //    }
    //    else if (oddsBars.currentValue >= 20f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 35;
    //        stars[2] = 60;
    //    }
    //    else if (oddsBars.currentValue >= 15f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 25;
    //        stars[2] = 70;
    //    }
    //    else if (oddsBars.currentValue >= 10f)
    //    {
    //        stars[0] = 5;
    //        stars[1] = 15;
    //        stars[2] = 80;
    //    }
    //    else
    //    {
    //        stars[0] = 5;
    //        stars[1] = 5;
    //        stars[2] = 90;
    //    }
    //    return stars;
    //}

}
