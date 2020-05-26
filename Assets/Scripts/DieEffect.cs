using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public GameObject dieEffect;
    bool isQuiting;
    bool isEnabled;
    public static bool playerDying;

    private void Awake()
    {
        isQuiting = false;
        playerDying = true;
    }
   

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
        if (!isQuiting && isEnabled && playerDying && !GameManager.isQuitingGame) Instantiate(dieEffect, transform.position, Quaternion.identity);

    }
}
