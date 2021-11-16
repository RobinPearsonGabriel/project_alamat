using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpecialDialogScript : MonoBehaviour
{
    [SerializeField] Text textbox;
    [SerializeField] Text nameText;
    [SerializeField] Image Background;
    [SerializeField] Image textboxSprite;
    [SerializeField] GameObject Panel;
    int Index;
    [SerializeField] DialogList lines ;  





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
        }
        else
        {
            textboxSprite.enabled = false;

        }
       


        Index++;
        if (lines.dialogs.Count <= Index)
        {
            Panel.SetActive (false);
            DialogEnd();
        }
    }
    void DialogEnd()
    {
    
    }    

}


