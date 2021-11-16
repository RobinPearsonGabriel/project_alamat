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
    [SerializeField] List<Line> lines;  
    [System.Serializable]
    public struct Line
    {

      
        public string name;
        public string sentence;
        public Sprite Bg;
        public Sprite characterSprite;
       
    }




    // Start is called before the first frame update
    void Start()
    {
        Index=0;    
        if (lines.Count > 0)
        {
            talking();
       
        
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

  public  void talking()
    {
        nameText.text = lines[Index].name;
        textbox.text = lines[Index].sentence;
        if (lines[Index].Bg != null)
        {
            Background.sprite = lines[Index].Bg;
        }
        if (lines[Index].characterSprite != null)
        {
            textboxSprite.enabled = true;
            textboxSprite.sprite = lines[Index].characterSprite;
        }
        else
        {
            textboxSprite.enabled = false;

        }
       


        Index++;
        if (lines.Count <= Index)
        {
            Panel.SetActive (false);
            DialogEnd();
        }
    }
    void DialogEnd()
    {
        
    }    

}


