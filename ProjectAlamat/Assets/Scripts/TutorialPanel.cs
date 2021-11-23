using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    public List<GameObject> tutorialImages= new List<GameObject>();
    public AudioClip pageChange;
    int currentPanel = 0;



    void Start()
    {
        if(tutorialImages[0] != null)
        {
            tutorialImages[0].SetActive(true);
        }
    }

    public void NextPage()
    {
        AudioManager.instance.PlayAudioClip(pageChange);
        tutorialImages[currentPanel].SetActive(false);
        currentPanel++;
        if (tutorialImages[currentPanel] != null)
        {
           tutorialImages[currentPanel].SetActive(true); 
        }
        else if(currentPanel > tutorialImages.Count)
        {
            LevelScript.instance.completeTutorial(true);
            this.gameObject.SetActive(false);
        }
    }
    public void PreviousPage()
    {
        tutorialImages[currentPanel].SetActive(false);
        currentPanel--;
        if (tutorialImages != null)
        {
            tutorialImages[currentPanel].SetActive(true);
        }
    }

    public void CloseTutorial()
    {
        AudioManager.instance.PlayAudioClip(pageChange);
        LevelScript.instance.completeTutorial(true);
        this.gameObject.SetActive(false);
    }
}
