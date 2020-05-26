using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public GameObject dieEffect;
    bool isQuiting;
    bool isEnabled;

    private void OnBecameVisible()
    {
        //Si el objeto no es visible, no puede spawnear
        isEnabled = true;
        Debug.Log(isEnabled);
    }

    private void OnApplicationQuit()
    {
        isQuiting = true;
    }
    public void OnDestroy()
    {
        if (!isQuiting && isEnabled) Instantiate(dieEffect, transform.position, Quaternion.identity);

    }
}
