using UnityEngine;

public class CoaguloLife : MonoBehaviour
{
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
            Destroy(gameObject);
        }
        else
        {
            disparo.tiempo *= 2;
        }
    }
}