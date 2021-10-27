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
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = newGameImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("saveFile" + SaveFileNumber.ToString(),"none") != "none")
        {
            this.gameObject.GetComponent<Image>().sprite = ContinueImage;
        }
    }


    public void ChangeButton()
    {
        this.gameObject.GetComponent<Image>().sprite = newGameImage;
    }
}
