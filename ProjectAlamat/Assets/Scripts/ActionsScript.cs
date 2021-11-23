using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.UI;

public class ActionsScript : MonoBehaviour
{
    public Camera camera;
    public GameObject sentencePanel;
    public Canvas actionCanvas;
    public Image enemyImage;
    public Image playerImage;
    public GameObject WinPanel;
    public float rotateMagnitude;

    private float cameraSize;

    void Start()
    {
        cameraSize = camera.orthographicSize;
    }

    public void ActivateWinPanel()
    {
        Debug.Log("Win");
        WinPanel.SetActive(true);
        Invoke("DeactivateWinPanel", 6.0f);
    }   

    void DeactivateWinPanel()
    {
       WinPanel.SetActive(false);
       LevelScript.instance.playerObj.transform.position = new Vector3(LevelScript.instance.playerObj.transform.position.x, LevelScript.instance.playerObj.transform.position.y, -5);
       LevelScript.instance.enemyObj.transform.position = new Vector3(LevelScript.instance.enemyObj.transform.position.x, LevelScript.instance.enemyObj.transform.position.y, -5);
    }

    public void ActivateActionCanvas(Sprite playersImage, Sprite enemysImage,bool playerAttacking)
    {
        if (playerAttacking)
        {
            playerImage.transform.SetAsLastSibling();
        }
        else
        {
            enemyImage.transform.SetAsLastSibling();
        }
        sentencePanel.SetActive(false);
        actionCanvas.gameObject.SetActive(true);
        enemyImage.sprite = enemysImage;
        enemyImage.SetNativeSize();
        playerImage.sprite = playersImage;
        playerImage.SetNativeSize();
        LevelScript.instance.playerObj.transform.position = new Vector3(LevelScript.instance.playerObj.transform.position.x, LevelScript.instance.playerObj.transform.position.y, -1);
        LevelScript.instance.enemyObj.transform.position = new Vector3(LevelScript.instance.enemyObj.transform.position.x, LevelScript.instance.enemyObj.transform.position.y, -1);

        Invoke("DeactivateActionCanvas", 3.0f);
    }

    void Update()
    {
    }

    void DeactivateActionCanvas()
    {
        playerImage.transform.rotation = new Quaternion(0, 0, 0, 0);
        enemyImage.transform.rotation = new Quaternion(0, 0, 0, 0);
        LevelScript.instance.playerObj.transform.position = new Vector3(LevelScript.instance.playerObj.transform.position.x, LevelScript.instance.playerObj.transform.position.y, -0.02f);
        LevelScript.instance.enemyObj.transform.position = new Vector3(LevelScript.instance.enemyObj.transform.position.x, LevelScript.instance.enemyObj.transform.position.y, -0.02f);
        sentencePanel.SetActive(true);
        actionCanvas.gameObject.SetActive(false);
        camera.transform.rotation = new Quaternion(0, 0, 0 ,0);
        camera.orthographicSize = cameraSize;
    }
}
