using UnityEngine;

public class DieEffect : MonoBehaviour
{
    public GameObject dieEffect;
    bool isQuiting;
    bool isEnabled;
    static bool playerDying;

    public static bool PlayerDying { get => playerDying; set => playerDying = value; }

    private void Awake()
    {
        isQuiting = false;
        PlayerDying = true;
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
        if (!isQuiting && isEnabled && PlayerDying) Instantiate(dieEffect, transform.position, Quaternion.identity);

    }
}
