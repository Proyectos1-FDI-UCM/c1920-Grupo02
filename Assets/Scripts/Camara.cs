using UnityEngine;

public class Camara : MonoBehaviour
{
    //Variable para seguir al jugador
    public Transform follow;

    void Update()
    {
        //Cambias el transform para que siempre siga al player
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
    }
}