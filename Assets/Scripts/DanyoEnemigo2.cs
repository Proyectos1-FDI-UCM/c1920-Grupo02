using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanyoEnemigo2 : MonoBehaviour
{
    public GameObject spawner;
    public int numGlobulosRojos;
    public int life;
    public GameObject escudo;
    private bool activar = false;

    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    private float time = 0.2f;

    private void Awake()
    {

        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {


        if (sprite != null)
        {
            if (damageRecieved > 0)
            {
                damageRecieved -= Time.deltaTime;
            }
            else
                sprite.color = new Color(1, 1, 1);

            if (damageRecieved > 0.40)
            {
                sprite.color = new Color(1, 1, 1, 0.7f);

            }
            else if (damageRecieved > 0.30)
            {
                sprite.color = new Color(1, 1, 1);
            }
            else if (damageRecieved > 0.20)
            {
                sprite.color = new Color(1, 1, 1, 0.7f);
            }
            else if (damageRecieved > 0.10)
            {
                sprite.color = new Color(1, 1, 1);
            }

        }
    }


    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        damageRecieved = 0.5f;
        // Variable booleana para que se bloquee uno de cada dos ataques
        if (Random.Range(0, 2) == 1)
        {

            life -= cant;
            print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
        }
        else
        {
           

            StartCoroutine(Activar());
            Debug.Log("Enemigo ha bloqueado el ataque");


            // Se puede incluir la animacion de bloqueo del ataque 

        }

        if (life <= 0)
        {
            //Spawnea globulos rojos
            spawner.GetComponent<SpawnerGlobulosRojos>().SpawnGlobulosRojos(numGlobulosRojos, gameObject.GetComponentInChildren<EnemyPatrol>().GetComponent<Transform>());
            //Destruye al enemigo
            Destroy(this.gameObject);
            print("Enemigo destruido");
        }

    }
    IEnumerator Activar()
    {
        escudo.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        escudo.SetActive(false); 

    }
}