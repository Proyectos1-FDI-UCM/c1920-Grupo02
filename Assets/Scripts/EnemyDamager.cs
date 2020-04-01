using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    RecibeDanyo enem; // datos del posible enemigo con el que colisionará

    // cantidad de daño infligida:
    public int danyoNormal; // en condiciones normales

    public float tiempoAtaque = 0.75f; // tiempo de vida

    void Start()
    {
        GameManager.instance.UpdateCanAtack(false); // actualización del estado de ataque

        Destroy(this.gameObject, tiempoAtaque); // autodestrucción a los "time" segundos
    }

    private void OnTriggerEnter2D(Collider2D objChocado) // al chocar con una cosa
    {
        enem = objChocado.GetComponentInParent<RecibeDanyo>(); // se guarda el componente característico de un enemigo

        if (enem != null) // si este no es nulo, se trata de un enemigo de verdad
        {
            enem.Dañado(danyoNormal); // se le pide al enemigo que baje su salud "danyoNormal" puntos
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.UpdateCanAtack(true); // actualización del estado de ataque
    }
}
// --- Javier