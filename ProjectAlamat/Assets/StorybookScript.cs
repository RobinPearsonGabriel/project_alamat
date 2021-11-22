using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorybookScript : MonoBehaviour
{
    public List<Sprite> Images = new List<Sprite>();
    public Image page;
    int currentPanel = 0;
    public GameObject NextButton;
    public GameObject PreviousButton;



    void Start()
    {
        currentPanel = 0;
        if (Images[0] != null)
        {
            page.sprite = Images[0];
            page.SetNativeSize();
            PreviousButton.SetActive(false);
        }
    }

    public void NextPage()
    {
        currentPanel++;
        if (currentPanel < Images.Count)
        {
            if (Images[currentPanel] != null)
            {
                PreviousButton.SetActive(true);
                page.sprite = Images[currentPanel];
                page.SetNativeSize();
            }
        }
        else if (currentPanel > Images.Count)
        {
            CloseBook();
        }
        
    }

    public void PreviousPage()
    {
        currentPanel--;
        if (Images[currentPanel] != null)
        {
            page.sprite = Images[currentPanel];
            page.SetNativeSize();
        }

        if(currentPanel==0)
        {
            PreviousButton.SetActive(false);
        }
    }

    public void CloseBook()
    {
        this.gameObject.SetActive(false);
        if (SpecialDialogScript.instance.AfterDialog)
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
