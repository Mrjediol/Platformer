using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressWithKeyboard : MonoBehaviour
{
    public Button buttonToPressQ;
    public Button buttonToPressW;
    public Button buttonToPressE;
    public Button buttonToPressR;
    public Button buttonToPressT;
    public Button buttonToPressA;
    public Button buttonToPressS;
    public Button buttonToPressD;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(buttonToPressQ != null)
            {
            buttonToPressQ.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (buttonToPressW != null)
            {
                buttonToPressW.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (buttonToPressE != null)
            {
                buttonToPressE.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (buttonToPressR != null)
            {
                buttonToPressR.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (buttonToPressT != null)
            {
                buttonToPressT.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (buttonToPressA != null)
            {
                buttonToPressA.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (buttonToPressS != null)
            {
                buttonToPressS.onClick.Invoke();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (buttonToPressD != null)
            {
                buttonToPressD.onClick.Invoke();
            }
        }
    }
}