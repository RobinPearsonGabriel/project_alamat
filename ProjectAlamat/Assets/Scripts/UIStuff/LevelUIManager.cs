using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public GameObject emptyPanel;
    public GameObject PausePanel;
    public GameObject SettingsPanel;

    [Header("LevelSelectionPanel")]
    public GameObject LevelSelectionPanel;
    public Text LevelNameText;
    private int levelSelected;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(emptyPanel);
    }

    public void OnPauseButtonClicked()
    {
        ActivatePanel(PausePanel);
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void OnLevelButtonClicked(int levelNumber)
    {
        levelSelected = levelNumber;
        LevelNameText.text = "Level " + levelSelected;
        ActivatePanel(LevelSelectionPanel);
    }

    public void OnYesButtonClicked()
    {
        SaveSystem.instance.SetCurrentLevel(levelSelected);
        SceneManager.LoadScene("Level"+levelSelected);

        //SceneManager.LoadScene("trial");
        Debug.Log("LoadingScene");
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnResumeButtonClicked()
    {
        ActivatePanel(emptyPanel);
    }

    public void OnRestartButtonClicked()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void OnLevelSelectionButtonClicked()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnSettingsButtonClicked()
    {
        ActivatePanel(SettingsPanel);
    }

   public void OnReturnButtonClicked()
    {
        ActivatePanel(PausePanel);
    }

    public void ContinueButtonPressed()
    {
        SaveSystem.instance.FinishCurrentLevel();
        SaveSystem.instance.SavePlayer();
        SceneManager.LoadScene("LevelSelection");
    }

    public void AdjustMusic()
    {
        //Adjust Music
    }

    public void AdjustSound()
    {
        //Adjust Sound
    }

    public void ActivatePanel(GameObject panelToBeActivated)
    {
        emptyPanel.SetActive(panelToBeActivated.Equals(emptyPanel));
        PausePanel.SetActive(panelToBeActivated.Equals(PausePanel));
        SettingsPanel.SetActive(panelToBeActivated.Equals(SettingsPanel));
        LevelSelectionPanel.SetActive(panelToBeActivated.Equals(LevelSelectionPanel));
    }
}
