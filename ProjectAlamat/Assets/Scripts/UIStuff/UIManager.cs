using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject savePanel;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(mainPanel);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void StartGameButton()
    {
        ActivatePanel(savePanel);
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


    public void GameButtonPressed(int saveNumber)
    {
        SaveSystem.instance.ChangeSaveNumber(saveNumber);
        SaveSystem.instance.Load();
        StartGame();
    }


    public void ActivatePanel(GameObject panelToBeActivated)
    {
        optionsPanel.SetActive(panelToBeActivated.Equals(optionsPanel));
        mainPanel.SetActive(panelToBeActivated.Equals(mainPanel));
        savePanel.SetActive(panelToBeActivated.Equals(savePanel));
    }

}
