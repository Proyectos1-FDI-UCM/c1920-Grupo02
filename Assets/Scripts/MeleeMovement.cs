using UnityEngine;

public class MeleeMovement : MonoBehaviour
{
    //Variables para mostrar que recive daños
    private float move;
    private void OnEnable()
    {
        move = 0;
        //transform.position = (transform.position + new Vector3(0.75f, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(0.75f, 0, 0), 1000*Time.deltaTime);
    }
    //Utilizamos el update para que cambie de color al recibir daño
    private void Update()
    {
        while(move<0.50)
        {
            transform.position = transform.position + new Vector3(move, 0, 0);
            move += 0.1f;
        }
        

    }
}
