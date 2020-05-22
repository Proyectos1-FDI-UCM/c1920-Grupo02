using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public GameObject dieEffect;
    bool isQuiting;

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }

    private void OnDestroy()
    {
        if(!isQuiting)Instantiate(dieEffect, transform.position, Quaternion.identity);
    }
}
