using UnityEngine;

public class PlayerRecibeDanyo : MonoBehaviour
{
    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    public void Dañado() 
    {
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
                sprite.color = new Color(1, 1, 1);

            if (damageRecieved > 0.40)
            {
                sprite.color = new Color(1, 1, 1, 0.7f);

            }
            else if (damageRecieved > 0.30)
            {
                sprite.color = new Color(1, 1, 1);
            }
            else if (damageRecieved > 0.20)
            {
                sprite.color = new Color(1, 1, 1, 0.7f);
            }
            else if (damageRecieved > 0.10)
            {
                sprite.color = new Color(1, 1, 1);
            }

        }
    }
}
