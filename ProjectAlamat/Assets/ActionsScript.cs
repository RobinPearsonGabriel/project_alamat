using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    public void ActivateActionCanvas(Sprite playersImage, Sprite enemysImage)
    {
        sentencePanel.SetActive(false);
        actionCanvas.gameObject.SetActive(true);
        enemyImage.sprite = enemysImage;
        enemyImage.SetNativeSize();
        playerImage.sprite = playersImage;
        playerImage.SetNativeSize();
        camera.orthographicSize = 3;
        camera.transform.Rotate(new Vector3(0, 0, rotateMagnitude));
        LevelScript.instance.playerObj.SetActive(false);
        LevelScript.instance.enemyObj.SetActive(false);

        Invoke("DeactivateActionCanvas", 3.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ActivateActionCanvas(null,null);
        }
    }

    void DeactivateActionCanvas()
    {
        LevelScript.instance.playerObj.SetActive(true);
        LevelScript.instance.enemyObj.SetActive(true);
        sentencePanel.SetActive(true);
        actionCanvas.gameObject.SetActive(false);
        camera.transform.rotation = new Quaternion(0, 0, 0 ,0);
        camera.orthographicSize = cameraSize;
    }
}
