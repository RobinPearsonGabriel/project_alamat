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
    private int levelSelected=0;

    [Header("Sound Settings")]
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource audioSource;

    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePanel(emptyPanel);
        audioSource.volume = PlayerPrefs.GetFloat("MusicLevel", audioSource.volume);
        soundSlider.value = PlayerPrefs.GetFloat("SoundLevel", soundSlider.value);
        musicSlider.value = audioSource.volume;
        volume = audioSource.volume;
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
        LevelNameText.text = "Proceed to Level " + levelSelected + "?";
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
        if (GameManager_Script.instance != null){
            GameManager_Script.instance.paused = false;
        }
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
        audioSource.volume = musicSlider.value;
        SaveVolumeLevel();
    }

    public void AdjustSound()
    {
        volume = soundSlider.value;
        SaveSoundLevel();
    }

    public void SaveVolumeLevel()
    {
        volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicLevel", volume);
    }

    public void SaveSoundLevel()
    {
        PlayerPrefs.SetFloat("SoundLevel", volume);
    }

    public void ActivatePanel(GameObject panelToBeActivated)
    {
        emptyPanel.SetActive(panelToBeActivated.Equals(emptyPanel));
        PausePanel.SetActive(panelToBeActivated.Equals(PausePanel));
        SettingsPanel.SetActive(panelToBeActivated.Equals(SettingsPanel));
        LevelSelectionPanel.SetActive(panelToBeActivated.Equals(LevelSelectionPanel));
    }
}
