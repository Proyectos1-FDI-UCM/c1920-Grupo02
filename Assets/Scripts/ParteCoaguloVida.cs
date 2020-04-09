using UnityEngine;

public class ParteCoaguloVida : MonoBehaviour
{
    private CoaguloLife vidaTotal;
    public int life;
    private void Awake()
    {
        vidaTotal = gameObject.GetComponentInParent<CoaguloLife>();
    }
    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
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