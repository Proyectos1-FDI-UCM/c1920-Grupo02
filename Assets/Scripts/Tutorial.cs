using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Image tutorialPhoto;       //Texto para el tutorial inicial
    public Image[] diagramaTutorial;

    int tutorialHecho = 0;
    void Start()
    {
        
    }
    public void TutorialTrigger(int num)
    {
        if (num == 0)
        {
            tutorialPhoto = diagramaTutorial[num];
            tutorialPhoto.enabled = true;
        }
        else if (num == 1 && tutorialHecho == 0)
        {
            tutorialPhoto = diagramaTutorial[num];
            tutorialHecho = 1;
        }
        else if (num == 2 && tutorialHecho == 1)
        {
            tutorialPhoto = diagramaTutorial[num];
            tutorialHecho = 2;
        }
        else if (num == 3 && tutorialHecho == 2)
        {
            tutorialPhoto = diagramaTutorial[num];
        }
        else if (num == 4)
        {
            tutorialPhoto = diagramaTutorial[num];
            tutorialHecho = 3;
        }
        else if (num == 5 && tutorialHecho == 3)
            tutorialPhoto.enabled =false;
        if (num == -1)
        {
            tutorialPhoto.enabled = true;
            //tutorial.text = "HAS MUERTO";
        }
    }
    void Update()
    {
        
    }
}
