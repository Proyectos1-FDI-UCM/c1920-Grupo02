using UnityEngine;

public class ChangePill1 : MonoBehaviour
{
    SpriteRenderer sprite;
    
    public Sprite pil_normal;
    public Sprite pil_lsd;
    public Sprite pil_homeopatica;

    private enum Pastilla
    {
        Nor, LSD, Hom
    }
    Pastilla estadoActual = Pastilla.Nor;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (Input.GetButtonDown("PrevCharacter"))
        {
            if (estadoActual != Pastilla.Nor) estadoActual--;
            Feedback();
        }
        
        
        if (Input.GetButtonDown("NextCharacter"))
        {
            if(estadoActual != Pastilla.Hom)estadoActual++;
            Feedback();
        }
        
    }

    void Feedback()
    {
        switch (estadoActual)
        {
            case Pastilla.Nor:
                Debug.Log("Pastilla normal");
                sprite.sprite = pil_normal;
                break;

            case Pastilla.LSD:
                Debug.Log("Pastilla LSD");
                sprite.sprite = pil_lsd;
                break;

            case Pastilla.Hom:
                Debug.Log("Pastilla homeopática");
                sprite.sprite = pil_homeopatica;
                break;
        }
    }
}