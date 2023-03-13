using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OddsBars : MonoBehaviour
{
    public Image progressBar;
    public float decrementAmount = 1.0f;
    public float updateInterval = 0.25f;

    private float currentValue = 100.0f;
    private bool isDecreasing = false;

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Ray"))
        {
            Debug.Log("Choco con ray" + currentValue);
            isDecreasing = true;
            InvokeRepeating("DecrementProgress", updateInterval, updateInterval);
        }

    }

    void DecrementProgress()
    {
        currentValue -= decrementAmount;
        progressBar.fillAmount = currentValue / 100.0f;
        Debug.Log(currentValue);
        if (currentValue <= 0.0f)
        {
            isDecreasing = false;
            CancelInvoke("DecrementProgress");
        }
    }
}
//En este script, la variable "progressBar" se refiere a la imagen que representa la barra de progreso. "decrementAmount" es la cantidad que disminuirá la barra de progreso en cada actualización, y "updateInterval" es el




