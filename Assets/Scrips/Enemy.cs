using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Vector3 startPos;
    private bool movingRight;

    void Start()
    {
        startPos = transform.position;
        // Generar número aleatorio para determinar dirección inicial del movimiento
        float rand = Random.Range(0f, 1f);
        movingRight = rand < 0.5f;
    }

    void Update()
    {
        // Mover hacia la derecha
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Mover hacia la izquierda y hacer flip en x
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Si alcanza el límite de movimiento a la derecha, cambiar de dirección
        if (transform.position.x >= startPos.x + 3f)
        {
            movingRight = false;
        }
        // Si alcanza el límite de movimiento a la izquierda, cambiar de dirección
        else if (transform.position.x <= startPos.x - 3f)
        {
            movingRight = true;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
