using UnityEngine;

/*Detecta la posición del jugador respecto del enemigo
 * mediante la variable pública direccion
 */

public class Coagulo_PlayerDetection : MonoBehaviour
{
    float movimiento;
    public Transform enemyTransform;
    public int direccion;
    public Vector2 attackDirection;
    private GranCoaguloLife granCoagulo;

    private void Awake()
    {
        granCoagulo = gameObject.GetComponentInParent<GranCoaguloLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (granCoagulo)
            granCoagulo.StartCombat();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        /*Movimiento detecta si el jugador se encuentra a la derecha o a la izquierda del enemigo
        y cambia la variable direccion en función de ello */
        attackDirection = (other.gameObject.transform.position - enemyTransform.position).normalized;
        movimiento = other.gameObject.transform.position.x - enemyTransform.position.x;
        if (movimiento > 0)
        {
            //Derecha
            direccion = 1;
        }
        else
        {
            //Izquierda
            direccion = -1;
        }
    }

    //Si el jugador sale del Trigger la dirección es 0
    private void OnTriggerExit2D(Collider2D collision)
    {
        direccion = 0;
    }
}