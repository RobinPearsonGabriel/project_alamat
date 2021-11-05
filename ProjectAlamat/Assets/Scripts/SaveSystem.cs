using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem: MonoBehaviour
{

    public static SaveSystem instance = null;
    public Player player;

    private int SaveFileNumber = 0;
    private int currentLevel = 0;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        player = this.gameObject.GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Load();
        }
    }

    public void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }

    public void FinishCurrentLevel()
    {
        player.levelsComplete[currentLevel] = true;
    }

    public void ChangeSaveNumber(int number)
    {
        Debug.Log(number);
        SaveFileNumber = number;
        Debug.Log(SaveFileNumber);
    }

    public void SavePlayer()
    {
        Debug.Log("Saving...");
        string json = JsonUtility.ToJson(player);
        Debug.Log(json);
        PlayerPrefs.SetString("saveFile" + SaveFileNumber.ToString(), json);
    }

    public void Load()
    {
        Debug.Log("Loading...");
        Debug.Log(SaveFileNumber);
        if (PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString(), "none") != "none")
        {
            string json = PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString());
            Debug.Log(json);
            JsonUtility.FromJsonOverwrite(json, player);
        }
        else
        {
            for (int x = 0; x < 7; x++)
            {
                player.levelsComplete[x] = false;
            }
            SavePlayer();
            string json = PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString());
            Debug.Log(json);
            JsonUtility.FromJsonOverwrite(json, player);
        }
    }
}
