using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelStars : MonoBehaviour
{
    // Start is called before the first frame update
    public Image oneStarImg;

    public Image twoStarsImg;

    public Image treeStarsImg;


    public int levelNumber;
    void Start()
    {
        TotalStars totalStars = GetComponentInParent<TotalStars>();
        string key = "level" + levelNumber + "Stars";
        int numStars = PlayerPrefs.GetInt(key, 0); // El segundo parámetro es el valor por defecto si no hay nada guardado en esa clave
        if (numStars == 3)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.white;
            treeStarsImg.color = Color.white;
            totalStars.AddToTotalStars(3);
        }
        else if (numStars == 2)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.white;
            treeStarsImg.color = Color.black;
            totalStars.AddToTotalStars(2);
        }
        else if (numStars == 1)
        {
            oneStarImg.color = Color.white;
            twoStarsImg.color = Color.black;
            treeStarsImg.color = Color.black;
            totalStars.AddToTotalStars(1);
        }
        Debug.Log(totalStars);
    }


}
