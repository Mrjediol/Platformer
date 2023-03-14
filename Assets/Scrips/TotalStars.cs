using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TotalStars : MonoBehaviour
{
    public TextMeshProUGUI totalStarsText;

    public int totalStars = 0;
    public void AddToTotalStars(int stars)
    {

        totalStars = totalStars + stars;
        totalStarsText.text = totalStars + " / 100";
    }

}
