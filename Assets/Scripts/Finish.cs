using UnityEngine;

public class Finish : MonoBehaviour
{
    public string travelTo;

    private void OnTriggerEnter2D(Collider2D other) // al chocar con una cosa
    {
        if (other.GetComponent<PlayerControllerWallJump>() != null) // si este no es nulo, se trata de un jugador de verdad
        {
            GameManager.instance.ChangeScene(travelTo); // se avanza de nivel
            //Tambien se guarda la partida
            //Falta implementar
        }
    }
}
// --- Javier