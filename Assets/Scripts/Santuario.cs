using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santuario : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si te quedas en la zona dañina...
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            //Y reseteas el timer
            timer = 0.3f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.AddLife(12);
        timer = 1;
    }
}
