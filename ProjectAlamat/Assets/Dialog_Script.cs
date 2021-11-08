using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Script : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI dialogTextBox;
    bool endLine=false;
    [SerializeField] SpriteRenderer Bg;
    [SerializeField]Character_Base AndesBase;
    [SerializeField] Character_Base EnemyBase;
    [SerializeField] Image Characterface;
    [SerializeField] GameObject namePanel;
    [SerializeField] Text nameText;
    [SerializeField] GameObject DialogPanel;
    [SerializeField] List<Sprite> bgSprite;
    [SerializeField] List<SpriteRenderer> sprite;
    [SerializeField] GameObject Ibneng;
    [SerializeField] Transform farleft, closeleft, closeright, farright;

    public enum SpeakerSprite { none, Andes, Enemy };

    string RoundText;
    List<Dialog> dialogs= new List<Dialog>();
    struct Dialog {
        SpeakerSprite Img;
        string Name;
        string Text;
        bool openCombat;
        DialogList.Pos pos;
        DialogList.Speaker speaker1;
        int bg;
  
        public string GetName()
        {
            return Name;
        }
        public string getText()
        {
            return Text;
        }

        public bool GetIsOpenInCombat()
        {
            return openCombat;
        }
        public SpeakerSprite GetImage()
        {
            return Img;
        }



        public DialogList.Pos GetPos()
        {
            return pos;
        }
        public DialogList.Speaker Getspeaker()
         {
            return speaker1;
            }
        public int GetBg()
        {
            return bg;
        }

       
        public Dialog(SpeakerSprite img,string name, string text,bool InCombat, DialogList.Pos Pos,DialogList.Speaker Speaker1,int Bg)
        {
          

            this.openCombat = InCombat;
            this.Img = img;
            this.Name = name;
            this.Text = text;

            this.pos=Pos;
             speaker1=Speaker1;
             this.bg=Bg;

        }
    
    
    }

    // Start is called before the first frame update
    void Start()
    {
        //  AddDialog(StartingDialog,false);
        // AddDialog(precombatDialog,false);
        Bg.sprite = bgSprite[3];
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    private void LateUpdate()
    {
        if (dialogs.Count > 0)
        {
            DialogPanel.SetActive(true);
            LevelScript.instance.setCanAnswer(false);
            if (Input.GetMouseButtonDown(0))
            {
                NextLine();
            }
        }
        else
        {
            Ibneng.SetActive(false);
            EnemyBase.SetPos(farright);
            AndesBase.SetPos(farleft);
        }
     
    }

    public void setRoundText(string Text,string name)
    {
        // namePanel.SetActive(true);
        DialogPanel.SetActive(false);
        // nameText.text = name;
        // dialogTextBox.text = Text;
    }



    public void AddDialog(string Text, bool incombat,string name,SpeakerSprite speaker, DialogList.Speaker speakerimg,DialogList.Pos pos)
    {

        


            SpeakerSprite image = speaker;
       
        //Characterface.enabled=false;
        string text = Text;
        Dialog dialog = new Dialog(image, name, text, incombat,pos, speakerimg, 0);

        dialogs.Add(dialog);
        //endLine = false;
        dialogTextBox.text = dialogs[0].getText();
        if (dialogs[0].GetName() != null || dialogs[0].GetName() != "")
        {
            namePanel.SetActive(true);
            nameText.text = dialogs[0].GetName();
            Characterface.color = Color.white;
        }

      
        setCharSprites(dialogs[0]);
    }

    public void AddDialogList(DialogList dialogeList, bool incombat)
    {

        for (int x = 0; x < dialogeList.dialogs.Count; x++)
        {
            SpeakerSprite image = SpeakerSprite.none;
            string Name = dialogeList.dialogs[x].getSpeaker();
            string text = dialogeList.dialogs[x].getDialog();
            Dialog dialog = new Dialog(image, Name, text, incombat, dialogeList.dialogs[x].pos, dialogeList.dialogs[x].speakerSprite, dialogeList.dialogs[x].Bg);

            dialogs.Add(dialog);

        }
        // endLine = false;
        LevelScript.instance.setCombatPanelActive(dialogs[0].GetIsOpenInCombat());
        dialogTextBox.text = dialogs[0].getText();
        if (dialogs[0].GetName() != null || dialogs[0].GetName() != "")
        {
            namePanel.SetActive(true);
            nameText.text = dialogs[0].GetName();
            Characterface.color = Color.white;
        }


     



        dialogTextBox.text = dialogs[0].getText();
        if (dialogs[0].GetName() != null || dialogs[0].GetName() != "")
        {
            namePanel.SetActive(true);
            nameText.text = dialogs[0].GetName();
            Characterface.color = Color.white;



          
        }

  setCharSprites(dialogs[0]);


    }
    Transform setPos(DialogList.Pos pos)
    {

        switch (pos)
        {
            case DialogList.Pos.closeleft:
                return closeleft;
                break;
            case DialogList.Pos.closeright:
                return closeright;
                break;
            case DialogList.Pos.farleft:
                return farleft;
                break;
            case DialogList.Pos.farright:
                return farright;
                break;

            default:
                return null;
                break;

        }
    }


    void setCharSprites(Dialog dialog)
    {
     
        Bg.sprite = bgSprite[Mathf.Clamp(dialog.GetBg(), 0, bgSprite.Count-1)];


        switch (dialog.Getspeaker())
        {
            case DialogList.Speaker.Andes:
                AndesBase.SetSpriteEndabled(true);
                AndesBase.SetPos(setPos(dialog.GetPos()));
                break;

            case DialogList.Speaker.Enemy:
                EnemyBase.SetSpriteEndabled(true);
                EnemyBase.SetPos(setPos(dialog.GetPos()));
                break;
            case DialogList.Speaker.Ibneng:
                Ibneng.SetActive(true);
                break;
            case DialogList.Speaker.NoOneSpeaking:
                AndesBase.SetSpriteEndabled(false);
                EnemyBase.SetSpriteEndabled(false);
                Ibneng.SetActive(false);
                break;
            default:
                break;


        }

    }

    public void NextLine()
    {


        Debug.Log("");

        dialogs.RemoveAt(0);


        
        


        if (dialogs.Count > 0)
        {
            dialogTextBox.text = dialogs[0].getText();
            if (dialogs[0].GetName() != null || dialogs[0].GetName() != "")
            {
                namePanel.SetActive(true);
                nameText.text = dialogs[0].GetName();
                Characterface.color = Color.white;

                setCharSprites(dialogs[0]);
            }
        }

        else
        {
            LevelScript.instance.onDialogEnd();

            namePanel.SetActive(false);
            nameText.text = "";
            Characterface.color = Color.clear;
            
        }



    }
}
