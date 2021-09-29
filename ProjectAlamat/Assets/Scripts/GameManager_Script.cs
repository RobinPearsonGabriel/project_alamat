using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager_Script : MonoBehaviour
{



    public static GameManager_Script instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
public  void PausePlayButton()
    {
        Time.timeScale = Time.timeScale==0?1:0;
    
    }

    //SceneManager
 public void NewScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


}
