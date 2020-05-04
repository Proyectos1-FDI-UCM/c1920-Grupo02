using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class TENIABOSS1 : MonoBehaviour
{
    // Start is called before the first frame update
     
    private float timer = 20;
    SpriteRenderer tenia;
  
    Vector3 tamañoactual;
    void Start()
    {
        tamañoactual = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); //Guardamos como de grande es al principio
        tenia= GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tiempo hasta desaparecer :" + timer);
        timer -= Time.deltaTime;
        if (timer <=0) //Una probabilidad entre 50
        {
            if (tenia.enabled == true)
            {
                              
                tenia.enabled = false; // lo hacemos invisible
            }
            else
            {
               
                tenia.enabled = true;//Si esta invisible que deje de serlo 
            }
            timer = 10f;

            //Quedaria aumentar la velocidad cachenado el script que le otorga una velocidad , si esa es variable publica



        }



    }
}

//El ataque puede ser que cada x tiempo , se vuelva invisible 
//Podriamos cachear el script que mueve a la tenia para que vya mas rapido, yu sea mas pequeño  y obliguq al jugador 