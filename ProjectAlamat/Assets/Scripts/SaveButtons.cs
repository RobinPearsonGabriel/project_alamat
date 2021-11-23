using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveButtons : MonoBehaviour
{
    public UIManager uiManager;
    public int SaveFileNumber;
    public Sprite newGameImage;
    public Sprite ContinueImage;
    public Button deleteButton;

    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<Image>().sprite = newGameImage;
        this.gameObject.transform.localPosition = new Vector3(511, this.gameObject.transform.localPosition.y, 0);
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(newGameImage.texture.width, newGameImage.texture.height);
        deleteButton.gameObject.SetActive(false);

        CheckButton();
    }

    public void ButtonClick()
    {
        if (SaveFileNumber != 0)
        {
            if (this.gameObject.GetComponent<Image>().sprite == ContinueImage)
            {
                uiManager.GameStart();
                uiManager.GameButtonPressed(SaveFileNumber);
            }
            else if (this.gameObject.GetComponent<Image>().sprite == newGameImage)
            {
                uiManager.NewGamePressed(SaveFileNumber);
            }
        }
        else
        {
            uiManager.GameStart();
        }
    }



    void CheckButton()
    {
        if (PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString(), "none") != "none")
        {
            this.gameObject.GetComponent<Image>().sprite = ContinueImage;
            this.gameObject.transform.localPosition = new Vector3(468, this.gameObject.transform.localPosition.y, 0);
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ContinueImage.texture.width, ContinueImage.texture.height);
            deleteButton.gameObject.SetActive(true);
        }
    }

}
