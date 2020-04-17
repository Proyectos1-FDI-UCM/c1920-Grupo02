using UnityEngine;

public class Camara : MonoBehaviour
{
    float time = 0;
    public Transform follow; //Variable para seguir al jugador
    void Update()
    {
        //Cambias el transform para que siempre siga al player
        transform.position = new Vector3(follow.position.x, follow.position.y, transform.position.z);
        if (time < 1)
        {
            GameManager.instance.ColorCamara(time);
            time += Time.deltaTime;
        }
        else
            time = 0;
    }
}