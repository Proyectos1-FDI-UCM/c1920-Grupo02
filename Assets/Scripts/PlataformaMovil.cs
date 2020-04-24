using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//En este script muevo la plataforma cada x segundo al punto especificado por el transform destino, 
//cuando llega a ese punto, vuelve al origen tras x segundos
public class PlataformaMovil : MonoBehaviour
{

    public Transform[] destino;

    //Velocidad de movimiento
    public int vMovimiento = 10;

    //Tiempo entre cada movimiento
    public float timeToMove;
    private bool canMove = true;

    //Posición actual
    int currentPos = 0;

    //Siguiente posición
    int nextPos = 1;

    void Update()
    {
        //Si han pasado timeToMove segundos desde el último movimiento, se inicia el movimiento a la posición correspondiente
        if (canMove)
            transform.position = Vector2.MoveTowards(transform.position, destino[nextPos].position, vMovimiento * Time.deltaTime);

        //Finalizado el movimiento, se cambia nextPos para que apuntes al siguiente punto, si está al final, regresa al punto inicial
        if (Vector2.Distance(transform.position, destino[nextPos].position) <= 0)
        {
            StartCoroutine(TimeToMove());
            currentPos = nextPos;
            nextPos++;

            if (nextPos > destino.Length - 1) nextPos = 0;
        }

    }

    /// <summary>
    /// Corrutina que gestiona el tiempo entre movimiento y movimiento
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeToMove()
    {
        canMove = false;
        yield return new WaitForSeconds(timeToMove);
        canMove = true;
    }
}
