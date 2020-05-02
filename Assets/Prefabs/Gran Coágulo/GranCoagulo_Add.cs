using UnityEngine;

public class GranCoagulo_Add : MonoBehaviour
{
    GranCoagulo_AddWave wave;

    private void Awake()
    {
        wave = gameObject.GetComponentInParent<GranCoagulo_AddWave>();
    }
    private void Start()
    {
        wave.OneAddMore();
    }
    private void OnDestroy()
    {
        if (wave != null)
            wave.AddKilled();
    }
}