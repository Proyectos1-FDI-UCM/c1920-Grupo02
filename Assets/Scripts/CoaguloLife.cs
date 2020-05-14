using UnityEngine;

public class CoaguloLife : MonoBehaviour
{
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private int numGlobulosRojos;
    private DispararCoagulo disparo;
    public int parts = 2;
    
    private void Awake()
    {
        disparo = gameObject.GetComponent<DispararCoagulo>();
    } 

    public void PartLost()
    {
        parts--;
        if (parts == 0)
        {
            spawner.GetComponent<SpawnerGlobulosRojos>().SpawnGlobulosRojos(numGlobulosRojos, gameObject.GetComponent<Transform>());
            Destroy(gameObject);
        }
        else
        {
            disparo.tiempo *= 2;
        }
    }
}