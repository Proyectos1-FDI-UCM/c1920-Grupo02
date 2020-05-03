using UnityEngine;

public class GranCoagulo_SecondAddWave : MonoBehaviour
{
    float initialTime;
    public float timeToKillAds;
    int numberOfAdds;
    GameObject oneShot;

    private void Awake()
    {
        oneShot = gameObject.GetComponentInChildren<GranCoagulo_OneShot>().gameObject;
        oneShot.SetActive(false);
    }

    private void Update()
    {
        if (Time.time > initialTime + timeToKillAds)
        {
            oneShot.SetActive(true);
        }
    }

    public void OneAddMore()
    {
        numberOfAdds++;
    }

    public void AddKilled()
    {
        numberOfAdds--;
        if (numberOfAdds <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        initialTime = Time.time;
    }
}