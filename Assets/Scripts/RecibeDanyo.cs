using UnityEngine;

public class RecibeDanyo : MonoBehaviour
{
    public GameObject spawner;
    public int numGlobulosRojos;
    public int life;

    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        life -= cant;
        if (life <= 0)
        {
            //Spawnea globulos rojos
            spawner.GetComponent<SpawnerGlobulosRojos>().SpawnGlobulosRojos(numGlobulosRojos,gameObject.GetComponentInChildren<EnemyPatrol>().GetComponent<Transform>());
            //Destruye al enemigo
            Destroy(this.gameObject);
            print("Enemigo destruido");
        }
        print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
    }
}