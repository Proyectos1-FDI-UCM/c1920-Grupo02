using UnityEngine;

public class DispararCoagulo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balaizq;
    public GameObject baladcha;
    float initialTime;
    public float tiempo;
    //private float timer = 2;
    PlayerDetection playerDetection;
    void Start()
    {
        playerDetection = GetComponentInChildren<PlayerDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initialTime > tiempo)
        {
            //Creacion de la Bala 
            if (playerDetection.direccion == -1) Instantiate(balaizq, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
            else Instantiate(baladcha, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);

            initialTime = Time.time;
        }

    }
    private void OnEnable()
    {
        initialTime = Time.time;
    }
}