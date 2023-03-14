using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OddsBars : MonoBehaviour
{

    public float currentValue; // valor actual de currentValue

    private Coroutine countdownCoroutine;

    public Slider chanceToWin;

    public TextMeshProUGUI chanceToWinText;

    public TextMeshProUGUI oneStarChanceText;

    public TextMeshProUGUI twoStarChanceText;

    public TextMeshProUGUI treeStarChanceText;

    public float oneStarsChance;
    public float twoStarsChance;
    public float treeStarsChance;
    private void Update()
    {
        chanceToWin.value = currentValue;
        if (currentValue <= 0)
        {
            ChangeSceneManager.changeSceneManager.ReLoadScene();
        }
        chanceToWinText.text = currentValue + " %";
        if (currentValue >= 50)
        {
            oneStarsChance = 0;
            oneStarChanceText.text = oneStarsChance + " %";
        }
        else
        {
            float result1 = 100 - currentValue * 2f;
            oneStarsChance = Mathf.Clamp(result1, 5, 90);
            oneStarChanceText.text = oneStarsChance + " %";
        }
        if (currentValue >= 53)
        {
            twoStarsChance = (100 - currentValue) * 2;
            twoStarChanceText.text = twoStarsChance + " %";
        }
        else
        {
            float result = currentValue * 2 - 5;
            twoStarsChance = Mathf.Clamp(result, 5, 95);
            twoStarChanceText.text = twoStarsChance + " %";
        }

        if (currentValue >= 53)
        {
            treeStarsChance = (currentValue - 50) * 2;
            treeStarChanceText.text = treeStarsChance + " %";
        }
        else
        {
            treeStarsChance = 5;
            treeStarChanceText.text = treeStarsChance + " %";
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ray"))
        {
            if (countdownCoroutine == null) // Si no está corriendo el coroutine
            {
                countdownCoroutine = StartCoroutine(Countdown()); // Iniciamos el coroutine
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ray"))
        {
            if (countdownCoroutine != null) // Si el coroutine está corriendo
            {
                StopCoroutine(countdownCoroutine); // Lo cancelamos
                countdownCoroutine = null; // Reiniciamos la variable
            }
        }
    }

    IEnumerator Countdown()
    {
        while (true)
        {
            currentValue = currentValue - 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
//En este script, la variable "progressBar" se refiere a la imagen que representa la barra de progreso. "decrementAmount" es la cantidad que disminuirá la barra de progreso en cada actualización, y "updateInterval" es el




