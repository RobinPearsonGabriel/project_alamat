using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Script : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogTextBox;
    bool endLine = false;
    [SerializeField] SpriteRenderer Bg;
    [SerializeField] GameObject AndesBase;
    [SerializeField] GameObject EnemyBase;
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
    List<Dialog> dialogs = new List<Dialog>();
    struct Dialog
    {
        SpeakerSprite Img;
        string Name;
        string Text;
        bool openCombat;
        DialogList.Pos pos;
        DialogList.Speaker speaker1;
        Character_BaseStat speaker;
        Sprite bg;

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

        public Character_BaseStat getSpeaker()
        {
            return speaker;
        }



        public DialogList.Pos GetPos()
        {
            return pos;
        }
        public DialogList.Speaker Getspeaker()
        {
            return speaker1;
        }
        public Sprite GetBg()
        {
            return bg;
        }


        public Dialog(SpeakerSprite img, string name, string text, bool InCombat, DialogList.Pos Pos, DialogList.Speaker Speaker1,Character_BaseStat speakerChar, Sprite Bg)
        {

          
            this.openCombat = InCombat;
            this.Img = img;
            this.Name = name;
            this.Text = text;
            this.speaker = speakerChar;
            this.pos = Pos;
            speaker1 = Speaker1;
            this.bg = Bg;

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        //  AddDialog(StartingDialog,false);
        // AddDialog(precombatDialog,false);

        // Bg.sprite = bgSprite[3];
        Bg.sprite = bgSprite[0];

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
            if (Input.GetMouseButtonDown(0) && !GameManager_Script.instance.paused)
            {
               
            }
        }
        else
        {
            Ibneng.SetActive(false);
            EnemyBase.transform.position = farright.position;
            AndesBase.transform.position = farleft.position;
        }

    }

    public void setRoundText(string Text, string name)
    {
        // namePanel.SetActive(true);
        DialogPanel.SetActive(false);
        // nameText.text = name;
        // dialogTextBox.text = Text;
    }



    public void AddDialog(string Text, bool incombat, string name, SpeakerSprite speaker, DialogList.Speaker speakerimg, DialogList.Pos pos)
    {




        SpeakerSprite image = speaker;

        //Characterface.enabled=false;
        string text = Text;
        Dialog dialog = new Dialog(image, name, text, incombat, pos, speakerimg, null ,null);

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
        LevelScript.instance.statsPanel.SetActive(false);
        LevelScript.instance.playerObj.SetActive(incombat);
        LevelScript.instance.enemyObj.SetActive(incombat);
        for (int x = 0; x < dialogeList.dialogs.Count; x++)
        {
            string Name = "";
            SpeakerSprite image = SpeakerSprite.none;
            if (dialogeList.dialogs[x].getSpeaker() != null)
            {
                Name = dialogeList.dialogs[x].getSpeaker().getName();
            }
            string text = dialogeList.dialogs[x].getDialog();
            Dialog dialog = new Dialog(image, Name, text, incombat, dialogeList.dialogs[x].pos, dialogeList.dialogs[x].speakerSprite,dialogeList.dialogs[x].speaker, dialogeList.dialogs[x].Bg);

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

        //Bg.sprite = bgSprite[Mathf.Clamp(dialog.GetBg(), 0, bgSprite.Count-1)];

        if (dialog.GetBg() != null)
        {
            Bg.sprite = dialog.GetBg();
        }

        if (dialog.getSpeaker() != null)
        {
            switch (dialog.Getspeaker())
            {
                case DialogList.Speaker.Andes:
                    AndesBase.SetActive(true);
                    Characterface.gameObject.SetActive(true);
                    Characterface.sprite = dialog.getSpeaker().getDialogImage();
                    AndesBase.gameObject.GetComponent<SpriteRenderer>().sprite = dialog.getSpeaker().getSpriteImage();
                    Characterface.SetNativeSize();
                    AndesBase.transform.position = setPos(dialog.GetPos()).position;
                    break;

                case DialogList.Speaker.Enemy:
                    EnemyBase.SetActive(true);
                    EnemyBase.GetComponent<SpriteRenderer>().sprite = dialog.getSpeaker().getSpriteImage();
                    Characterface.gameObject.SetActive(true);
                    Characterface.sprite = dialog.getSpeaker().getDialogImage();
                    Characterface.SetNativeSize();
                    EnemyBase.transform.position = setPos(dialog.GetPos()).position;
                    break;
                case DialogList.Speaker.Ibneng:
                    Ibneng.SetActive(true);
                    Ibneng.GetComponent<SpriteRenderer>().sprite = dialog.getSpeaker().getSpriteImage();
                    Characterface.sprite = dialog.getSpeaker().getDialogImage();
                    Characterface.SetNativeSize();
                    Ibneng.transform.position = setPos(dialog.GetPos()).position;
                    break;
                case DialogList.Speaker.NoOneSpeaking:
                    Characterface.gameObject.SetActive(false);
                    Characterface.SetNativeSize();
                    break;
                default:
                    break;


            }
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
            LevelScript.instance.playerObj.SetActive(true);
            LevelScript.instance.enemyObj.SetActive(true);
            LevelScript.instance.TutorialCheck();
            AndesBase.SetActive(false);
            EnemyBase.SetActive(false);
            Ibneng.SetActive(false);
            namePanel.SetActive(false);
            nameText.text = "";
            Characterface.color = Color.clear;

        }



    }
}
