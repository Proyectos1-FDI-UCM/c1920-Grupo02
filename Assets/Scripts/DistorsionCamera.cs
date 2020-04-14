using UnityEngine;

public class DistorsionCamera : MonoBehaviour
{
   public Camera maincamara; // Asociamos camara
    public float cantidad = 0; // Cantidad de movimento 
    public int tiempo; // Variable para decidir cuanto dura la distorsion


    private void Start()
    {
        //Cacheamos la camara
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int aleatorio = Random.Range(0, 2);
        if (collision.gameObject.GetComponent<PlayerController>()!=null && aleatorio == 1 )
        {
            Shake(cantidad, tiempo);
        }



    }



}
