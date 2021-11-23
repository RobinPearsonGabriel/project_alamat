using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject mainPanel;
    public GameObject savePanel;
    public GameObject confirmationPanel;
    public GameObject creditsPanel;

    [Header("Sound Settings")]
    public Slider musicSlider;
    public Slider soundSlider;
    public AudioSource audioSource;
    public AudioSource soundSource;

    private float volume;
    
    [SerializeField]private int saveNumber;

    // Start is called before the first frame update
    void Start()
    {

        ActivatePanel(mainPanel);
        soundSource.volume = 0;
        audioSource.volume = PlayerPrefs.GetFloat("MusicLevel", audioSource.volume);
        soundSlider.value = PlayerPrefs.GetFloat("SoundLevel", soundSlider.value);
        soundSource.volume = soundSlider.value;
        musicSlider.value = audioSource.volume;
        volume = audioSource.volume;
    }

    void Awake()
    {
        saveNumber=0;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("LevelSelection");
    }

    IEnumerator NewGame()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Prologue");
    }

    public void StartGameButton()
    {
        soundSource.Play();
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

    public void OpenConfirmation(int Number) {
        saveNumber = Number;
        confirmationPanel.SetActive(!confirmationPanel.activeSelf);
    }

    public void YesDelete()
    {
        if (PlayerPrefs.HasKey("saveFile" + saveNumber.ToString()))
        {
            Debug.Log("Key Exists");
            PlayerPrefs.DeleteKey("saveFile" + saveNumber.ToString());
            Debug.Log("Deleting Key");
            confirmationPanel.SetActive(!confirmationPanel.activeSelf);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {
            Debug.Log("DeleteFailed");
        }
    }

    public void BackButton()
    {
        ActivatePanel(mainPanel);
    }

    public void NewGamePressed(int saveNumber)
    {
        Debug.Log(saveNumber);
        SaveSystem.instance.ChangeSaveNumber(saveNumber);
        SaveSystem.instance.Load();
        StartCoroutine("NewGame");
    }

    public void ChangeMusicVolume()
    {
        audioSource.volume = musicSlider.value;
        SaveVolumeLevel();
    }

    public void ChangeSoundVolume()
    {
        volume = soundSlider.value;
        soundSource.volume = volume;
        if (!soundSource.isPlaying)
        {
            soundSource.Play();
        }
        SaveSoundLevel();
    }

    public void SaveVolumeLevel()
    {
        volume = audioSource.volume;
        PlayerPrefs.SetFloat("MusicLevel", volume);
    }

    public void SaveSoundLevel()
    {
        PlayerPrefs.SetFloat("SoundLevel", volume);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("LevelSelection");
    }


    public void GameButtonPressed(int saveNumber)
    {
  
        Debug.Log(saveNumber);
        SaveSystem.instance.ChangeSaveNumber(saveNumber);
        SaveSystem.instance.Load();
        StartCoroutine("StartGame");
    }


    public void ActivatePanel(GameObject panelToBeActivated)
    {
        soundSource.Play();
        optionsPanel.SetActive(panelToBeActivated.Equals(optionsPanel));
        mainPanel.SetActive(panelToBeActivated.Equals(mainPanel));
        savePanel.SetActive(panelToBeActivated.Equals(savePanel));
        creditsPanel.SetActive(panelToBeActivated.Equals(creditsPanel));
    }

}
