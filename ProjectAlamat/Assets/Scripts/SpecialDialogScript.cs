using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpecialDialogScript : MonoBehaviour
{
    [SerializeField] Text textbox;
    [SerializeField] Text nameText;
    [SerializeField] Image Background;
    [SerializeField] Image textboxSprite;
    [SerializeField] GameObject Panel;
    public GameObject Storybook;
    public bool AfterDialog;
    int Index;
    [SerializeField] DialogList lines ;

    public static SpecialDialogScript instance = null;
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
        Index=0;

        if (lines != null)
        {

            if (lines.dialogs.Count > 0)
            {
                talking();


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

  public  void talking()
    {
        if (lines.dialogs.Count <= Index)
        {
            Panel.SetActive(false);
            DialogEnd();
        }
        else
        {
            nameText.text = lines.dialogs[Index].getSpeakerName();
            textbox.text = lines.dialogs[Index].sentence;
            if (lines.dialogs[Index].Bg != null)
            {
                Background.sprite = lines.dialogs[Index].Bg;
            }
            if (lines.dialogs[Index].speaker.DialogSprite != null)
            {
                textboxSprite.enabled = true;
                textboxSprite.sprite = lines.dialogs[Index].speaker.DialogSprite;
                textboxSprite.SetNativeSize();
            }
            else
            {
                textboxSprite.enabled = false;

            }



            Index++;
        }
    }

    void DialogEnd()
    {
        if (AfterDialog)
        {
            Storybook.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("LevelSelection");
        }
    }    

}


