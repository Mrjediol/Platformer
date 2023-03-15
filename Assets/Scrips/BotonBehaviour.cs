using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotonBehaviour : MonoBehaviour
{
    public GameObject textToActivate;
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
    }

    public void UnSelected()
    {
        textToActivate.SetActive(false);
    }
}
