using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public GameObject emptyPanel;
    public GameObject PausePanel;
    public GameObject SettingsPanel;

    [Header("LevelSelectionPanel")]
    public GameObject LevelSelectionPanel;
    private int levelSelected;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(emptyPanel);
    }

    public void OnPauseButtonClicked()
    {
        PausePanel.SetActive(!PausePanel.activeInHierarchy);
    }

    public void OnLevelButtonClicked(int levelNumber)
    {
        levelSelected = levelNumber;
        ActivatePanel(LevelSelectionPanel);
    }

    public void OnYesButtonClicked()
    {
        //SceneManager.LoadScene("Level"+levelSelected);
        SceneManager.LoadScene("trial");
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
        SceneManager.LoadScene("LevelSelection");
        SaveSystem.instance.player.levelsComplete[levelSelected] = true;
        SaveSystem.instance.SavePlayer();
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
