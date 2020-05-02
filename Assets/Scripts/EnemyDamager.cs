using UnityEngine;

public class EnemyDamager : MonoBehaviour
{

    RecibeDanyo enem; // datos del posible enemigo con el que colisionará

    ParteCoaguloVida coagulo; //datos del posible coágulo con el que colisionará    --> Miguel

    ParteGranCoagulo granCoagulo; //datos del posible Gran Coágulo con el que colisionará --> Miguel

    DanyoEnemigo2 colesterol; //datos del posible colesterol con el que colisionará

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

        coagulo = objChocado.GetComponent<ParteCoaguloVida>();      // --> Miguel

        granCoagulo = objChocado.GetComponent<ParteGranCoagulo>();

        colesterol = objChocado.GetComponentInParent<DanyoEnemigo2>();

        if (enem != null) // si este no es nulo, se trata de un enemigo de verdad
            enem.Dañado(danyoNormal); // se le pide al enemigo que baje su salud "danyoNormal" puntos

        //Miguel
        if (coagulo != null) // si este no es nulo, se trata de un coágulo de verdad
            coagulo.Dañado(danyoNormal); // se le pide al coágulo que baju su salud "danyoNormal" puntos

        if (granCoagulo != null)
            granCoagulo.Dañado(danyoNormal);

        if (colesterol != null)
            colesterol.Dañado(danyoNormal);
    }

    private void OnDestroy()
    {
        GameManager.instance.UpdateCanAtack(true); // actualización del estado de ataque
    }
}
// --- Javier