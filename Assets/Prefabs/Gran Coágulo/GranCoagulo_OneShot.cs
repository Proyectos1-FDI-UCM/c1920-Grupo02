using UnityEngine;

public class GranCoagulo_OneShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.LoseLife(100);
    }
}