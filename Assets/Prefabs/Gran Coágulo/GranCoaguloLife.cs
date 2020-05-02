using UnityEngine;

public class GranCoaguloLife : MonoBehaviour
{
    private DisparoDeSangre disparo;
    public int parts = 3;

    //Ads
    private GameObject wave1;
    private GameObject wave2;

    private void Awake()
    {
        disparo = gameObject.GetComponent<DisparoDeSangre>();
        wave1 = gameObject.GetComponentInChildren<GranCoagulo_AddWave>().gameObject;
        wave1.SetActive(false);
    }
    public void PartLost()
    {
        parts--;
        if (parts == 0)
        {
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