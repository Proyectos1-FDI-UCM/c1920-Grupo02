using UnityEngine;

public class DistorsionCamera : MonoBehaviour
{
    private Camera maincamara; // Asociamos camara
    public float cantidad = 0; // Cantidad de movimento 
    public int tiempo; // Variable para decidir cuanto dura la distorsion
    private Camara camera;


    private void Start()
    {
        maincamara = Camera.main;
        camera = maincamara.GetComponent<Camara>(); //Cacheo de el script camara de la camara principal
    }
    void Shake(float amt, float length) // Metodo que conecta la invocacion de el movimiento y tras un tiempo lo quita con el Cancel Invoke

    {
        cantidad = amt;
        camera.enabled = false;
        InvokeRepeating("DoShake", 0, 0.05f);
        Invoke("StopShake", length);
        camera.enabled = true;
    }

    void DoShake()  //Ajustamos los ejex X e y y se los añadimso a la camara para crear este efecto de distorsion
    {

        if (cantidad > 0)
        {
            Vector3 posicioncamara = maincamara.transform.position;
            float ejeX = Random.value * cantidad * 2 - cantidad;
            float ejeY = Random.value * cantidad * 2 - cantidad;
            posicioncamara.x += ejeX;
            posicioncamara.y += ejeY;
            maincamara.transform.position = posicioncamara;
        }
    }
    void StopShake() // Con este metodo paramos el metodo de distorsion
    {
        CancelInvoke("DoShake");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null)
        {
            FXManager.PlaySound("TaeniaBite");
            Shake(cantidad, tiempo);

        }



    }



}
