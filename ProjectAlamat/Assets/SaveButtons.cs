using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveButtons : MonoBehaviour
{
    public int SaveFileNumber;
    public Sprite newGameImage;
    public Sprite ContinueImage;

    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<Image>().sprite = newGameImage;
        this.gameObject.transform.localPosition = new Vector3(511, this.gameObject.transform.localPosition.y, 0);
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(newGameImage.texture.width, newGameImage.texture.height);

        CheckButton();
    }



    void CheckButton()
    {
        if (PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString(), "none") != "none")
        {
            this.gameObject.GetComponent<Image>().sprite = ContinueImage;
            this.gameObject.transform.localPosition = new Vector3(468, this.gameObject.transform.localPosition.y, 0);
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ContinueImage.texture.width, ContinueImage.texture.height);
        }
    }

}
