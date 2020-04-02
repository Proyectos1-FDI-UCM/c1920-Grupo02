using UnityEngine;

public class Disparar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balaizq;
    public GameObject baladcha;
    float initialTime;
    public float tiempo;
    //private float timer = 2;
    SpriteRenderer cuerpo;
    void Start()
    {
        cuerpo = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initialTime > tiempo)
        {
            //Creacion de la Bala 
            if (cuerpo.flipX == true) Instantiate(balaizq, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
            else Instantiate(baladcha, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);

            initialTime = Time.time;
        }

    }
    private void OnEnable()
    {
        initialTime = Time.time;
    }
}