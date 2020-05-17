using UnityEngine;

public class ParteGranCoagulo : MonoBehaviour
{
    private GranCoaguloLife vidaTotal;
    public int life;

    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    private void Awake()
    {
        vidaTotal = gameObject.GetComponentInParent<GranCoaguloLife>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();

    }
    public void Update()
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