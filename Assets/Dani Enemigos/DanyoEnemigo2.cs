using UnityEngine;

public class DanyoEnemigo2 : MonoBehaviour
{
    public GameObject spawner;
    public int numGlobulosRojos;
    public int life;
    int bloqueo = 0;

    private void Start()
    {

    }
    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        // Variable booleana para que se bloquee uno de cada dos ataques
        if (bloqueo >= 4)
        {
            life -= cant;
            bloqueo = 0;
            print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
        }
        else
        {
            Debug.Log("Enemigo ha bloqueado el ataque");
            bloqueo++;
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
}
