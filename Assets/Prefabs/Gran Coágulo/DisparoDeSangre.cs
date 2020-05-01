using UnityEngine;

public class DisparoDeSangre : MonoBehaviour
{
    public GameObject bala;
    float initialTime;
    public float tiempo;
    public int bulletsPerVolley;
    public float timeBetweenBullets;
    private float firedBullets = 0;
    private GameObject tempBala;
    Coagulo_PlayerDetection playerDetection;
    void Start()
    {
        playerDetection = GetComponentInChildren<Coagulo_PlayerDetection>();
    }

    void Update()
    {
        if (Time.time - initialTime > tiempo)
        {
            StartVolley();
            initialTime = Time.time;
        }
    }

    private void StartVolley()
    {
            InvokeRepeating("FireBullet", 0f, timeBetweenBullets);
    }
    private void FireBullet()
    {
        if (firedBullets >= bulletsPerVolley)
        {
            firedBullets = 0;
            CancelInvoke();
        }
        else
        {
            tempBala = Instantiate(bala, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);

            tempBala.gameObject.transform.right = playerDetection.attackDirection;

            firedBullets++;
        }
    }
    private void OnEnable()
    {
        initialTime = Time.time;
    }
}