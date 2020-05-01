using UnityEngine;

public class DisparoDeSangre : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;
    float initialTime;
    public float tiempo;
    private GameObject tempBala;
    //private float timer = 2;
    Coagulo_PlayerDetection playerDetection;
    void Start()
    {
        playerDetection = GetComponentInChildren<Coagulo_PlayerDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time - initialTime+ " > " +tiempo);
        if (Time.time - initialTime > tiempo)
        {
            //Creacion de la Bala 

            tempBala = Instantiate(bala, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);

            tempBala.gameObject.transform.right = playerDetection.attackDirection;

            initialTime = Time.time;
        }
        


    }
    private void OnEnable()
    {
        initialTime = Time.time;
    }
}