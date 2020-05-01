using UnityEngine;

public class RecibeDanyo : MonoBehaviour
{
    public GameObject spawner;
    public int numGlobulosRojos;
    public int life;
    public GameObject puerta;
    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        life -= cant;
        if (life <= 0)
        {
            if (spawner != null)
            {
                //Spawnea globulos rojos
                spawner.GetComponent<SpawnerGlobulosRojos>().
                    SpawnGlobulosRojos(numGlobulosRojos, gameObject.GetComponentInChildren<EnemyPatrol>().GetComponent<Transform>());
            }
            //Destruye al enemigo
            // Habria que llamar al metodo confirma boss, que verifica si tiene el Componente Distorsion de camara
            // Si es asi , el Objeto publico puerta, se destruye justo cuando muere la Tenia Boss
            if (GetComponentInChildren<DistorsionCamera>()!=null) Destroy(puerta);
            Destroy(this.gameObject);
            print("Enemigo destruido");
        }
        print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
    }
}