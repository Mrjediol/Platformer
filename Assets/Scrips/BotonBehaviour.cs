using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonBehaviour : MonoBehaviour
{
    public GameObject textToActivate;
    public GameObject textToActivate2;
    public GameObject textToActivate3;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ImSelected();
    }
    private void OnDisable()
    {
        UnSelected();
    }

    public void ImSelected()
    {
        textToActivate.SetActive(true);
        textToActivate2.SetActive(true);
        textToActivate3.SetActive(true);
    }

    public void UnSelected()
    {
        textToActivate.SetActive(false);
        textToActivate2.SetActive(false);
        textToActivate3.SetActive(false);
    }
}
