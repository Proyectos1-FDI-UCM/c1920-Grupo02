using UnityEngine.SceneManagement;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string level;
    public int health;
    public int globulosRojos;
    //public int globulsoBlancos;
    //Por ahora no es necesario Obtener la posicion
    //public float[] position;

    public PlayerData(GameManager player)
    {
        level = SceneManager.GetActiveScene().name;
        health = player.getLife;
        globulosRojos = player.ReturnGlobulosRojos();
        //globulsoBlancos = player.ReturnGlobulosBlancos();
    }
  
}
