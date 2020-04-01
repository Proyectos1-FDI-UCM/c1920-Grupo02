using UnityEngine;

public class SpawnerGlobulosRojos : MonoBehaviour
{
    public GameObject globuloRojo;
    private Vector2 spawnPoint;
    private float margenDeAparicion;

    //Coloca los glóbulos rojos colocados correctamente
    public void SpawnGlobulosRojos(int numGlobulosRojos, Transform spawnPosition)
    {
        margenDeAparicion = (numGlobulosRojos - 1) * 0.5f;
        for (int i = 0; i < numGlobulosRojos; i++)
        {
            spawnPoint = new Vector2(spawnPosition.position.x - margenDeAparicion + i * 0.75f, spawnPosition.position.y);
            Instantiate(globuloRojo, spawnPoint, Quaternion.identity);
        }
    }
}