using UnityEngine;

public class MeleeMovement : MonoBehaviour
{
    private float cantidad;
    public float move;
    public float limiteMovimiento;
    private void OnEnable()
    {
        //Establece la variable a 0 para usarla 2 veces y ahorrar espacio
        cantidad = 0;
    }
    private void Update()
    {
        //Si esta mirando a la derecha...
        if (GameManager.instance.GetPlayerLooking() == 1)
        {
            //Lo mueve a la derecha
            while (cantidad <limiteMovimiento)
            {
                transform.position = transform.position + new Vector3(cantidad, 0, 0);
                cantidad += move;

            }
        }
        //Si esta mirando a la izquierda...
        else if (GameManager.instance.GetPlayerLooking() == -1)
        {
            //Lo mueve a la izquierda
            while (cantidad > -limiteMovimiento)
            {
                //Me mueve el transform hasta cierto punto
                transform.position = transform.position + new Vector3(cantidad, 0, 0);
                cantidad -= move;
            }

        }
        this.enabled = false;
    }
}
