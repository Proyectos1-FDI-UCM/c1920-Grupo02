using UnityEngine;

public class PlayerRecibeDanyo : MonoBehaviour
{
    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    
    public void Dañado() 
    {
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        damageRecieved = 0.5f;
    }
    //Utilizamos el update para que cambie de color al recibir daño
    private void Update()
    {
        if (sprite != null)
        {
            if (damageRecieved > 0)
            {
                damageRecieved -= Time.deltaTime;
            }
            else
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b);

            if (damageRecieved > 0.40)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f);
                Debug.Log("Parpadeo");

            }
            else if (damageRecieved > 0.30)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b);
                Debug.Log("Ahora no");

            }
            else if (damageRecieved > 0.20)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f);
                Debug.Log("Parpadeo");

            }
            else if (damageRecieved > 0.10)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b);
                Debug.Log("Ahora no");

            }
        }
        
    }
}
