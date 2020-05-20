﻿using UnityEngine;

public class GranCoagulo_OneShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("OneShot", 1.5f);
    }

    void OneShot()
    {
        GameManager.instance.LoseLife(100);
    }
}