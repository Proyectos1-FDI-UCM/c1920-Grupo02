using UnityEngine;

public class GranCoagulo_AddWave : MonoBehaviour
{
    float initialTime;
    public float timeToKillAds;
    int numberOfAdds;

    private void Update()
    {
        /*if (Time.time > initialTime + timeToKillAds)
        {
            //Hacer explosión
            Destroy(gameObject);
        }*/
    }

    public void OneAddMore()
    {
        numberOfAdds++;
    }

    public void AddKilled()
    {
        numberOfAdds--;
        if (numberOfAdds < 0)
        {
            //Notificar al Gran Coágulo!!!!
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        initialTime = Time.time;
    }
}