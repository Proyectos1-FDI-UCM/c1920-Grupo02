using UnityEngine;

public class tutorial : MonoBehaviour
{
    private TextMesh tutorialText;
    public int numberTutorial;
    private float time;
    public Rigidbody2D rb;
    void Start()
    {
        numberTutorial = 0;
        tutorialText = gameObject.GetComponent<TextMesh>();
        tutorialText.text = "Pulsa A-D o LeftArrow-RightArrow \n para moverte";
    }

    void Update()
    {

        //Temporizador
        if (time <= 0)
        {
            time = 0;

            if(numberTutorial == 1) 
            {
                tutorialText.text = "Pulsa W o UpArrow para saltar";

            }
            else if (numberTutorial == 2)
            {
                tutorialText.text = "Pulsa Z o Shift para disparar con ella";
                numberTutorial++;
            }
        }
        else
        {
            time -= Time.deltaTime;
        }


        if ((rb.velocity.x > 1|| rb.velocity.x < -1) && numberTutorial == 0)
        {
            numberTutorial++;
            time = 1;
        }
        else if (rb.velocity.y > 1 && numberTutorial==1)
        {
            numberTutorial++;
            time = 3;
            tutorialText.text = "Ahora eres una pastilla de ibuprofeno";
        }
        else if (/*Input.GetKeyDown(KeyCode.Z) && */numberTutorial == 3)    //CAMBIAR POR INPUT DEL USUARIO
        {
            tutorialText.text = "Coge el PowerUp para poder cambiar de pastilla";
        }
        else if (numberTutorial == 4)
        {
            tutorialText.text = "Pulsa V o B para cambiar de pastilla";
        }
    }
    public void SumaTutorial()
    {
        numberTutorial++;
    }
}
