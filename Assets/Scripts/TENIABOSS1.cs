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
    EnemyPatrol patrulla;
    private Rigidbody2D rb;
    Vector3 tamañoactual;
    void Start()
    {
        tamañoactual = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); //Guardamos como de grande es al principio
        tenia= GetComponent<SpriteRenderer>();
        patrulla = GetComponent<EnemyPatrol>(); //Cacheamos el script de patrullaje
        rb = GetComponent<Rigidbody2D>();
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
                rb.velocity = new UnityEngine.Vector2(rb.velocity.x * 4, rb.velocity.y * 4); //Se le aplica una velocidad 3 veces la anterior
               
            }
            else
            {
                rb.velocity = new UnityEngine.Vector2(rb.velocity.x / 4f, rb.velocity.y /4f); //Su velocidad vuelve a ser normal 

                tenia.enabled = true;//Si esta invisible que deje de serlo 
            }
            timer = 10f;

             //He pensado en reducir su tamaño pero no se como hacerlo sin buguearlo  
            



        }



    }
} 