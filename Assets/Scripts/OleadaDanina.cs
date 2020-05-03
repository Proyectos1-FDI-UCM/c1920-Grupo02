using UnityEngine;

public class OleadaDanina : MonoBehaviour
{
    public Transform destino;
    public int velocidad = 10;
    public int damage;
    public float contador;
    private void OnEnable()
    {
        //Dejamos 3s para que el jugador se entere
        contador = 3;
        //Metemos el animator1
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Si se choca con el jugador
        if (collider.gameObject.GetComponent<PlayerControllerWallJump>())
        {
            //Le hace mucho daño
            GameManager.instance.LoseLife(damage);
        }
    }

    private void Update()
    {
        //Cuando el contador llegue a 0...
        if (contador > 0)
            contador -= Time.deltaTime;
        else
            //Se desplaza
            transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);
    }
}
