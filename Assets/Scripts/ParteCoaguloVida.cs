using UnityEngine;

public class ParteCoaguloVida : MonoBehaviour
{
    private CoaguloLife vidaTotal;
    public int life;

    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    private void Awake()
    {
        vidaTotal = gameObject.GetComponentInParent<CoaguloLife>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
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
    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        damageRecieved = 0.5f;
        life -= cant;
        if (life <= 0)
        {
            vidaTotal.PartLost();
            //Destruye al enemigo
            Destroy(this.gameObject);
            print("Parte destruida");
        }
        print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
    }
}