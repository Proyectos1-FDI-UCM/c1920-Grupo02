using UnityEngine;

public class DeterminaTamanyo : MonoBehaviour
{
    public float sizeMultiplier;

    private Vector3 tam = new Vector3();

    void Start()
    {
        if(sizeMultiplier > 0)
        {
            tam = gameObject.transform.localScale;

            transform.localScale = new Vector3(sizeMultiplier * tam.x, sizeMultiplier * tam.y, 0);
        }
    }
}
