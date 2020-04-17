using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoBala : MonoBehaviour
{
    // Start is called before the first frame update
    public int daño = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerControllerWallJump>() != null) GameManager.instance.LoseLife(1);
        Destroy(this.gameObject);


    }
}
