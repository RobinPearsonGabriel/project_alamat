using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mainPanel;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(mainPanel);
    }

    public void StartGame()
    {
        //Check if there is a json file on the computer if yes load game if not start a new game
        SceneManager.LoadScene("LevelSelection");
    }

    public void ExitGame()
    {
        Debug.Log("ExitButton Pressed");
        Application.Quit();
    }

    public void OptionsButton()
    {
        Debug.Log("OptionsButton Pressed");
        ActivatePanel(optionsPanel);
    }

    public void BackButton()
    {
        ActivatePanel(mainPanel);
    }

    public void ChangeMusicVolume()
    {

    }

    public void ChangeSoundVolume()
    {

    }


    public void ActivatePanel(GameObject panelToBeActivated)
    {
        optionsPanel.SetActive(panelToBeActivated.Equals(optionsPanel));
        mainPanel.SetActive(panelToBeActivated.Equals(mainPanel));
    }

}
