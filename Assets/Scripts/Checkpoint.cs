using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int amplitud;
    int i;
    float velocidad;
    bool floatup;
    bool detectado;         //boolean que te sirve para saber cuando "Player" ha entrado en algún momento al trigger
    SpriteRenderer color;
    Checkpoint habilitar;
    void Start()
    {
        detectado = false;
        velocidad = 0.03f;  //velocidad a la que se desplaza el GO
        amplitud = 50;      //distancia vertical en la que se desplaza el GO
        i = 0;              //variable auxiliar que nos sirve para desplazar el GO respecto a la amplitud
        floatup = true;     //Boolean que sirve para controlar el estado en el que se encuentra el GO (subiendo o bajando)
        color = GetComponent<SpriteRenderer>(); //Cacheo de SpriteRenderer para poder controlar el color del GO
        color.color = Color.gray;
        habilitar = GetComponent<Checkpoint>(); //Cacheo del script para deshabilitarlo
        habilitar.enabled = true;
    }
    void Update()
    {
        if (floatup)
        { 
            floatingup();
        }
        else if (!floatup)
        {
            floatingdown();

        }
    }
    void floatingup()       //Bucle para esplazar hacia arriba el GO
    {
        if (i < amplitud)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidad);
            i++;
        }
        else
        {
            floatup = false;
            i = 0;
        }
    }
    void floatingdown()     //Bucle para esplazar hacia abajo el GO
    {
        if (i < amplitud)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidad);
            i++;
        }
        else
        {
            if (detectado)
            {
                //El script se desactiva una vez el checkpoint se incrusta en el suelo
                habilitar.enabled = false;  //Para desactivar este script cuando el jugador toque el checkpoint
            }
            floatup = true;
            i = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            detectado = true;
        }
    }
    private void OnDisable()            //Cuando se deshabilita este script, el checkpoint se incrusta en el suelo y cambia de color para mostrar que está activado el checkpoint
    {
        color.color = new Color(0, 250, 250);
    }
}
