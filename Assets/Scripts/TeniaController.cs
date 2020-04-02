using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class TeniaController : MonoBehaviour
{
    EnemyFollow enemyFollow;
    EnemyPatrol enemyPatrol;
    PlayerDetection playerDetection;
    bool detectingPlayer;
    float initialExecutionTime;
    float initialStartOfMovementTime;
    bool alreadyCounting;

    public float timeBeforeMordiscoAbominable;
    public float executionTime;
    Enemy_MordiscoAbominable mordiscoAbominable;
    public EnemyPatrolLimit enemyLeftPatrolLimit;
    public EnemyPatrolLimit enemyRightPatrolLimit;
    

    //Referencias
    void Start()
    {
        enemyFollow = gameObject.GetComponent<EnemyFollow>();
        enemyPatrol = gameObject.GetComponentInChildren<EnemyPatrol>();
        playerDetection = gameObject.GetComponentInChildren<PlayerDetection>();
        mordiscoAbominable = gameObject.GetComponentInChildren<Enemy_MordiscoAbominable>();
    }

    private void Update()
    {
        if(detectingPlayer == true)
        {
            if (Time.time-initialExecutionTime > timeBeforeMordiscoAbominable && !enemyLeftPatrolLimit.atLimit && !enemyRightPatrolLimit.atLimit)
            {
                mordiscoAbominable.enabled = true;
                enemyPatrol.enabled = false;
                enemyFollow.enabled = false;
                initialStartOfMovementTime = Time.time;
            }
        }
        else
        {
            initialExecutionTime = Time.time + 78502345f;
            alreadyCounting = false;
        }
        if (mordiscoAbominable.enabled && Time.time-initialStartOfMovementTime > executionTime)
        {
            mordiscoAbominable.enabled = false;
        }
        if (Time.time - initialExecutionTime > timeBeforeMordiscoAbominable + executionTime)
        {
            alreadyCounting = false;
        }
        
    }

    private void FixedUpdate()
    {
        //Si el enemigo está en los limites de patrullaje:
        if (enemyLeftPatrolLimit.atLimit || enemyRightPatrolLimit.atLimit)
        {
            //Se para
            enemyPatrol.enabled = false;
            enemyFollow.enabled = false;
            mordiscoAbominable.enabled = false;
            //En el momento en el que el jugador no sea detectado:
            if (playerDetection.direccion == 0)
            {
                //El enemigo sigue patrullando
                enemyLeftPatrolLimit.atLimit = false;
                enemyRightPatrolLimit.atLimit = false;
                enemyPatrol.enabled = true;
                detectingPlayer = false;
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
                    detectingPlayer = true;
                    if (!alreadyCounting && !mordiscoAbominable.enabled)
                        StartMordiscoCD();
                }
                if (enemyRightPatrolLimit.atLimit && playerDetection.direccion == -1)
                {
                    enemyLeftPatrolLimit.atLimit = false;
                    enemyRightPatrolLimit.atLimit = false;
                    enemyFollow.enabled = true;
                    detectingPlayer = true;
                    if (!alreadyCounting && !mordiscoAbominable.enabled)
                        StartMordiscoCD();
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
                detectingPlayer = false;
                mordiscoAbominable.enabled = false;
            }
            //Si detecta al jugador
            else
            {
                //Le sigue
                enemyFollow.enabled = true;
                enemyPatrol.enabled = false;
                detectingPlayer = true;
                if (!alreadyCounting && !mordiscoAbominable.enabled)
                    StartMordiscoCD();
            }
        }
    }
    private void StartMordiscoCD()
    {
        alreadyCounting = true;
        initialExecutionTime = Time.time;
    }
}