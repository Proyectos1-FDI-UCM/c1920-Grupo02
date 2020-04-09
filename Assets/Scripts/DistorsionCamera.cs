using UnityEngine;

public class DistorsionCamera : MonoBehaviour
{
    private Camera maincamara; // Asociamos camara
    public float cantidad = 0; // Cantidad de movimento 
    public int tiempo; // Variable para decidir cuanto dura la distorsion
    private void Start()
    {
        //Cacheamos la camara
        maincamara = gameObject.GetComponent<Camera>();
    }
    public void Shake(float amt, float length) // Metodo que conecta la invocacion de el movimiento y tras un tiempo lo quita con el Cancel Invoke

    {
        cantidad = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
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
    void Update() // Llamada al efecto de distorsion solo cuando pulsas tecla (forma de probar si funciona , con el enemico estara asociado a una colision)
    {
        //Testeo, en un futuro cambiaremos el GetKey
        if (Input.GetKey(KeyCode.P))
        {
            Shake(cantidad, tiempo);
        }
    }
}
