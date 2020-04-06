using UnityEngine;

/*Máquina de estados del enemigo
    Cede el control al resto de scripts que contiene el GameObject Enemigo
    y sus hijos según lo requiera la situación.
    */

public class TeniaController : MonoBehaviour
{
    //Referencias a Scripts
    EnemyFollow enemyFollow;
    EnemyPatrol enemyPatrol;
    PlayerDetection playerDetection;
    Enemy_MordiscoAbominable mordiscoAbominable;

    //Variables de control
    bool detectingPlayer;
    float initialExecutionTime;
    float initialStartOfMovementTime;
    bool alreadyCounting;
    Rigidbody2D rb;

    //Variables de testeo
    public float timeBeforeMordiscoAbominable;
    public float executionTime;
    
    //Referencias públicas
    public EnemyPatrolLimit enemyLeftPatrolLimit;
    public EnemyPatrolLimit enemyRightPatrolLimit;
    

    //Referencias
    void Start()
    {
        enemyFollow = gameObject.GetComponent<EnemyFollow>();
        enemyPatrol = gameObject.GetComponentInChildren<EnemyPatrol>();
        playerDetection = gameObject.GetComponentInChildren<PlayerDetection>();
        mordiscoAbominable = gameObject.GetComponentInChildren<Enemy_MordiscoAbominable>();
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        //Si está detectando al jugador
        if(detectingPlayer == true)
        {
            //Si el enemigo ha visto al jugador durante timeBeforeMordiscoAbominable
            //y no se encuentra en los límites de patrullaje:
            if (Time.time-initialExecutionTime > timeBeforeMordiscoAbominable && !enemyLeftPatrolLimit.atLimit && !enemyRightPatrolLimit.atLimit)
            {
                //Habilita y deshabilita scripts
                mordiscoAbominable.enabled = true;
                enemyPatrol.enabled = false;
                enemyFollow.enabled = false;

                //Se establece el tiempo inicial como tiempo de inicio del movimiento
                initialStartOfMovementTime = Time.time;
            }
        }
        //Si no se detecta al jugador o el enemigo se encuentra en los límites
        else
        {
            //Se asigna un valor imposible al tiempo inicial de ejecución para evitar bugs de una forma sencilla
            initialExecutionTime = Time.time + 78502345f;

            //Ya no se está contando el tiempo
            alreadyCounting = false;
        }

        //Situaciones anormales que pueden ocurrir:
        //Si se está realizando mordiscoAbominable y ya se ha finalizado el tiempo del movimiento
        if (mordiscoAbominable.enabled && Time.time-initialStartOfMovementTime > executionTime)
        {
            //Se desactiva el script
            mordiscoAbominable.enabled = false;

            //Ya no se está contando y se asigna una variable imposible a initialExecutionTime
            alreadyCounting = false;
            initialExecutionTime = Time.time + 78502345f;
            rb.velocity = new Vector2(0, 0);
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