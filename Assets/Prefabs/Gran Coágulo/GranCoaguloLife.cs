using UnityEngine;

public class GranCoaguloLife : MonoBehaviour
{
    private DisparoDeSangre disparo;
    public int parts = 3;

    private void Awake()
    {
        disparo = gameObject.GetComponent<DisparoDeSangre>();
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