using UnityEngine;

public class RecibeDanyo : MonoBehaviour
{
    public GameObject spawner;
    public int numGlobulosRojos;
    public int life;
    public GameObject puerta;

    //Variables para mostrar que recive daños
    private float damageRecieved;
    private SpriteRenderer sprite;
    //DieEffect effect;
    private void Awake()
    {
        //effect = gameObject.GetComponentInChildren<DieEffect>();
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    public void Dañado(int cant) // se recibe "cant" puntos de daño
    {
        damageRecieved = 0.5f;
        life -= cant;
        if (life <= 0)
        {
            //effect.Efecto();
            if (spawner != null)
            {
                //Spawnea globulos rojos
                spawner.GetComponent<SpawnerGlobulosRojos>().
                    SpawnGlobulosRojos(numGlobulosRojos, gameObject.GetComponentInChildren<EnemyPatrol>().GetComponent<Transform>());
            }
            //Destruye al enemigo
            // Habria que llamar al metodo confirma boss, que verifica si tiene el Componente Distorsion de camara
            // Si es asi , el Objeto publico puerta, se destruye justo cuando muere la Tenia Boss
            if (GetComponentInChildren<DistorsionCamera>() != null) Destroy(puerta);
            
            Destroy(this.gameObject);
            print("Enemigo destruido");
        }
        print("enemigo es dañado por " + cant + " unidades"); /// PLACEHOLDER
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

            if (damageRecieved> 0.40)
            {
                sprite.color = new Color(1,1,1,0.7f);

            }
            else if(damageRecieved > 0.30)
            {
                sprite.color = new Color(1,1,1);
            }
            else if (damageRecieved >0.20)
            {
                sprite.color = new Color(1,1,1,0.7f);
            }
            else if (damageRecieved >0.10)
            {
                sprite.color = new Color(1,1,1);
            }

        }
    }
}