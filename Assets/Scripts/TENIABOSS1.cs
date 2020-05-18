using UnityEngine;

public class TENIABOSS1 : MonoBehaviour
{
    // Start is called before the first frame update
     
    private float timer = 3;
    SpriteRenderer tenia;
    private Rigidbody2D rb;
    Vector3 tamañoactual;
    void Start()
    {
        
        tenia= GetComponent<SpriteRenderer>();    
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tiempo hasta desaparecer :" + (int)timer);
        timer -= Time.deltaTime;
        if (timer <=0) //Cuando llegue a cero 
        {
            if (tenia.enabled == true)
            {
                              
                tenia.enabled = false; // lo hacemos invisible
                rb.velocity = new UnityEngine.Vector2(rb.velocity.x * 4, rb.velocity.y); //Se le aplica una velocidad 4 veces la anterior
               
            }
            else
            {
                rb.velocity = new UnityEngine.Vector2(rb.velocity.x / 4f, rb.velocity.y); //Su velocidad vuelve a ser normal 
                tenia.enabled = true;//Si esta invisible que deje de serlo 
            }
            timer = 3;

             //He pensado en reducir su tamaño pero no se como hacerlo sin buguearlo  
            



        }



    }
} 