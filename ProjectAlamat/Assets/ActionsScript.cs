using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsScript : MonoBehaviour
{
    public Camera camera;
    public Canvas mainCanvas;
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
        //VictoryPanel.SetActive(true);
        Invoke("DeactivateWinPanel", 1.0f);
    }   

    void DeactivateWinPanel()
    {
       WinPanel.SetActive(false);
    }

    public void ActivateActionCanvas(Sprite playersImage, Sprite enemysImage)
    {
        mainCanvas.gameObject.SetActive(false);
        actionCanvas.gameObject.SetActive(true);
        enemyImage.sprite = enemysImage;
        playerImage.sprite = playersImage;
        camera.orthographicSize = 4;
        camera.transform.Rotate(new Vector3(0, 0, rotateMagnitude));

        Invoke("DeactivateActionCanvas", 1.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //ActivateActionCanvas();
        }
    }

    void DeactivateActionCanvas()
    {
        mainCanvas.gameObject.SetActive(true);
        actionCanvas.gameObject.SetActive(false);
        camera.transform.rotation = new Quaternion(0, 0, 0 ,0);
        camera.orthographicSize = cameraSize;
    }
}
