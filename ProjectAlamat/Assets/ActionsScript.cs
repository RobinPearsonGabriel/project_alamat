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
    public Sprite gag;
    public Sprite burh;
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
            playerImage.transform.Rotate(0,0,-rotateMagnitude,Space.Self);
            enemyImage.transform.Rotate(0, 0, -rotateMagnitude, Space.Self);
            camera.orthographicSize = 3;
            camera.transform.Rotate(new Vector3(0, 0, rotateMagnitude));
            playerImage.transform.SetAsLastSibling();
        }
        else
        {
            playerImage.transform.Rotate(0, 0, rotateMagnitude, Space.Self);
            enemyImage.transform.Rotate(0, 0, rotateMagnitude, Space.Self);
            camera.orthographicSize = 3;
            camera.transform.Rotate(new Vector3(0, 0, -rotateMagnitude));
            enemyImage.transform.SetAsLastSibling();
        }
        sentencePanel.SetActive(false);
        actionCanvas.gameObject.SetActive(true);
        enemyImage.sprite = enemysImage;
        enemyImage.SetNativeSize();
        playerImage.sprite = playersImage;
        playerImage.SetNativeSize();
        LevelScript.instance.playerObj.transform.position = new Vector3(LevelScript.instance.playerObj.transform.position.x, LevelScript.instance.playerObj.transform.position.y, -5);
        LevelScript.instance.enemyObj.transform.position = new Vector3(LevelScript.instance.enemyObj.transform.position.x, LevelScript.instance.enemyObj.transform.position.y, -5);

        Invoke("DeactivateActionCanvas", 3.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActivateActionCanvas(gag, burh, true);
        }
    }

    void DeactivateActionCanvas()
    {
        playerImage.transform.rotation = new Quaternion(0, 0, 0, 0);
        enemyImage.transform.rotation = new Quaternion(0, 0, 0, 0);
        LevelScript.instance.playerObj.transform.position = new Vector3(LevelScript.instance.playerObj.transform.position.x, LevelScript.instance.playerObj.transform.position.y, 0);
        LevelScript.instance.enemyObj.transform.position = new Vector3(LevelScript.instance.enemyObj.transform.position.x, LevelScript.instance.enemyObj.transform.position.y, 0);
        sentencePanel.SetActive(true);
        actionCanvas.gameObject.SetActive(false);
        camera.transform.rotation = new Quaternion(0, 0, 0 ,0);
        camera.orthographicSize = cameraSize;
    }
}
