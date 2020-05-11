using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class EnemyController : MonoBehaviour
{
    EnemyFollow enemyFollow;
    EnemyPatrol enemyPatrol;
    PlayerDetection playerDetection;
    public EnemyPatrolLimit enemyLeftPatrolLimit;
    public EnemyPatrolLimit enemyRightPatrolLimit;
    

    //Referencias
    void Start()
    {
        enemyFollow = gameObject.GetComponent<EnemyFollow>();
        enemyPatrol = gameObject.GetComponentInChildren<EnemyPatrol>();
        playerDetection = gameObject.GetComponentInChildren<PlayerDetection>();
    }


    private void FixedUpdate()
    {
        //Si el enemigo está en los limites de patrullaje:
        if (enemyLeftPatrolLimit.atLimit || enemyRightPatrolLimit.atLimit)
        {
            //Se para
            enemyPatrol.enabled = false;
            enemyFollow.enabled = false;
            //En el momento en el que el jugador no sea detectado:
            if (playerDetection.direccion == 0)
            {
                //El enemigo sigue patrullando
                enemyLeftPatrolLimit.atLimit = false;
                enemyRightPatrolLimit.atLimit = false;
                enemyFollow.enabled = false;
                enemyPatrol.enabled = true;
            }

            //Si el enemigo detecta al jugador:
            else
            {
                //Si puede acercarse al jugador sin salirse de los limites lo hace
                if (enemyLeftPatrolLimit.atLimit && playerDetection.direccion == 1)
                {
                    enemyLeftPatrolLimit.atLimit = false;
                    enemyRightPatrolLimit.atLimit = false;
                    enemyFollow.enabled = true;
                }
                if (enemyRightPatrolLimit.atLimit && playerDetection.direccion == -1)
                {
                    enemyLeftPatrolLimit.atLimit = false;
                    enemyRightPatrolLimit.atLimit = false;
                    enemyFollow.enabled = true;
                }
            }
        }

        //Si el enemigo no se encuentra en los límites:
        else
        {
            //Si el enemigo no detecta al jugador:
            if (playerDetection.direccion == 0)
            {
                //Patrulla
                enemyPatrol.enabled = true;
                enemyFollow.enabled = false;
            }
            //Si detecta al jugador
            else
            {
                //Le sigue
                enemyFollow.enabled = true;
                enemyPatrol.enabled = false;
            }
        }
    }
}