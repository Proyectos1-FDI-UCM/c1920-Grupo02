using UnityEngine;

public class GranCoagulo_Add : MonoBehaviour
{
    GranCoagulo_FirstAddWave wave1;
    GranCoagulo_SecondAddWave wave2;

    private void Awake()
    {
        wave1 = gameObject.GetComponentInParent<GranCoagulo_FirstAddWave>();
        wave2 = gameObject.GetComponentInParent<GranCoagulo_SecondAddWave>();
    }
    private void Start()
    {
        if (wave1 != null)
            wave1.OneAddMore();
        else
        {
            if (wave2 != null)
                wave2.OneAddMore();
        }
    }
    private void OnDestroy()
    {
        if (wave1 != null)
            wave1.AddKilled();
        else
        {
            if (wave2 != null)
                wave2.AddKilled();
        }
    }
}