using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform follow; //Variable para seguir al jugador
    void Start()
    {
    }
    void Update()
    {
        //Cambias el transform para que siempre siga al player
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
        GameManager.instance.ColorCamara();
    }
}