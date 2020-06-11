using UnityEngine;

public class Santuario : MonoBehaviour
{
    float timer;
    bool done;
    SpriteRenderer sprite;
    void Start()
    {
        done = false;
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite != null)
        {
            //Si te quedas en la zona dañina...
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                sprite.color = new Color(1, 1, 1, timer/5);
                done = true;
            }
            else if (timer <= 0 && done)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Le sanas
        GameManager.instance.AddLife(12);
        if (!done)
        {
            FXManager.PlaySound("Sanacion");
            //Empieza a desaparecer
            timer = 5;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameManager.instance.AddLife(12);
    }
}
