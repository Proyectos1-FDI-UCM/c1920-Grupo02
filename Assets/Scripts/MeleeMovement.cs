using UnityEngine;

public class MeleeMovement : MonoBehaviour
{
    private float move;
    private void OnEnable()
    {
        //Establece la variable a 0 para usarla 2 veces y ahorrar espacio
        move = 0;
    }
    private void Update()
    {
        //Si esta mirando a la derecha...
        if (GameManager.instance.GetPlayerLooking() == 1)
        {
            //Lo mueve a la derecha
            while (move < 0.50)
            {
                transform.position = transform.position + new Vector3(move, 0, 0);
                move += 0.1f;

            }
        }
        //Si esta mirando a la izquierda...
        else if (GameManager.instance.GetPlayerLooking() == -1)
        {
            //Lo mueve a la izquierda
            while (move > -0.50)
            {
                //Me mueve el transform hasta cierto punto
                transform.position = transform.position + new Vector3(move, 0, 0);
                move -= 0.1f;
            }

        }
    }
}
