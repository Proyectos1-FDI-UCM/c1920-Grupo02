using UnityEngine;

public class GranCoaguloLife : MonoBehaviour
{
    private DisparoDeSangre disparo;
    public int parts = 3;

    //Ads
    private GameObject wave1;
    private GameObject wave2;

    public GameObject door;

    private void Awake()
    {
        disparo = gameObject.GetComponent<DisparoDeSangre>();
        wave1 = gameObject.GetComponentInChildren<GranCoagulo_FirstAddWave>().gameObject;
        wave1.SetActive(false);
        wave2 = gameObject.GetComponentInChildren<GranCoagulo_SecondAddWave>().gameObject;
        wave2.SetActive(false);
    }
    public void PartLost()
    {
        parts--;
        if (parts == 0)
        {
            Destroy(door);
            Destroy(gameObject);
        }
        else
        {
            if (parts == 2)
            {
                wave1.SetActive(true);
            }
            else
            {
                if (parts == 1)
                    wave2.SetActive(true);
            }
            disparo.tiempo *= 2;
        }
    }
}