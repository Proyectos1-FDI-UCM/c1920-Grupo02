using UnityEngine;

/*Detecta si el enemigo se encuentra en el límite de patrullaje,
 * en cuyo caso atLimit es true.
 * En el momento en el que el enemigo sale del limite atLimit = false
 */

public class EnemyPatrolLimit : MonoBehaviour
{
    //Referencia del enemigo en concreto
    public GameObject enemy;

    public bool atLimit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            atLimit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            atLimit = false;
        }
    }
}