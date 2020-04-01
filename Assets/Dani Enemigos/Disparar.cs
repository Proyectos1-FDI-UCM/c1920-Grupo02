using UnityEngine;

public class Disparar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject body;
    public GameObject bala;
    private float timer = 2;
    SpriteRenderer cuerpo;
    void Start()
    {
         cuerpo = body.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            //Lo vas restando
            timer -= Time.deltaTime;
        }
        //Si el timer ya está en 0...
        else if (timer <= 0)
        {
            //Creacion de la Bala 
            if (cuerpo.flipX==true) Instantiate<GameObject>(bala, new Vector3(body.transform.position.x -2, body.transform.position.y, body.transform.position.z), body.transform.rotation);
            else if (cuerpo.flipX==false)      Instantiate<GameObject>(bala, new Vector3(body.transform.position.x +2, body.transform.position.y, body.transform.position.z), body.transform.rotation);
            Debug.Log("Eres gilipollas");
            //Y reseteas el timer
            timer = 1;
        }

;
    }
}
