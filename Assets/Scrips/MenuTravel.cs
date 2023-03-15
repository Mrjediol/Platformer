using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTravel : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;

    private Button[] levelButtons;
    private int currentLevelIndex = 0;

    void Start()
    {
        // Crear una matriz de botones para el menu de niveles
        levelButtons = new Button[] { level1, level2, level3 };

        // Establecer el boton inicialmente seleccionado
        levelButtons[currentLevelIndex].Select();
        SetSelectedButton(currentLevelIndex);
    }

    void Update()
    {
        // Detectar la entrada del teclado para la izquierda (A) y la derecha (D)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Deseleccionar el boton actualmente seleccionado
            levelButtons[currentLevelIndex].GetComponent<Image>().color = Color.white;

            // Mover el indice del boton hacia la izquierda
            currentLevelIndex--;
            if (currentLevelIndex < 0)
            {
                currentLevelIndex = levelButtons.Length - 1;
            }

            // Seleccionar el nuevo boton y cambiar su color a rojo
            SetSelectedButton(currentLevelIndex);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Deseleccionar el boton actualmente seleccionado
            levelButtons[currentLevelIndex].GetComponent<Image>().color = Color.white;

            // Mover el indice del boton hacia la derecha
            currentLevelIndex++;
            if (currentLevelIndex >= levelButtons.Length)
            {
                currentLevelIndex = 0;
            }

            // Seleccionar el nuevo boton y cambiar su color a rojo
            SetSelectedButton(currentLevelIndex);
        }
        // Detectar la entrada del teclado para Enter
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Obtener el boton actualmente seleccionado y simular un clic en el
            levelButtons[currentLevelIndex].onClick.Invoke();
        }
    }
    void SetSelectedButton(int index)
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i == index)
            {
                // Establecer el boton seleccionado
                levelButtons[i].Select();
                levelButtons[i].GetComponent<Image>().color = Color.red;
                levelButtons[i].transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                // Activar el script BotonBehaviour
                BotonBehaviour botonBehaviour = levelButtons[i].GetComponent<BotonBehaviour>();
                if (botonBehaviour)
                    botonBehaviour.enabled = true;

            }
            else
            {
                // Establecer el boton deseleccionado
                levelButtons[i].GetComponent<Image>().color = Color.white;
                levelButtons[i].transform.localScale = Vector3.one;

                // Desactivar el script BotonBehaviour
                BotonBehaviour botonBehaviour = levelButtons[i].GetComponent<BotonBehaviour>();
                if (botonBehaviour)
                    botonBehaviour.enabled = false;
            }
        }
    }
}

