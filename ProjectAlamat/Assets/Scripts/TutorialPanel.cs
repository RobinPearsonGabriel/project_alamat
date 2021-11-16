using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public List<Sprite> tutorialImages= new List<Sprite>();
    public Image panelImage;
    int currentPanel = 0;



    void Start()
    {
        if(tutorialImages[0] != null)
        {
            panelImage.sprite = tutorialImages[0];
        }
    }

    public void NextPage()
    {
        currentPanel++;
        if (tutorialImages[currentPanel] != null)
        {
            panelImage.sprite = tutorialImages[0];
        }
        else if(currentPanel > tutorialImages.Count)
        {
            LevelScript.instance.completeTutorial(true);
            this.gameObject.SetActive(false);
        }
    }
}
