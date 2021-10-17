using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog_Script : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogTextBox;
    bool endLine=false;

    [SerializeField]Image Andes;
    [SerializeField]Image Enemy;




    public enum SpeakerSprite { none, Andes, Enemy };

    string RoundText;
    List<Dialog> dialogs= new List<Dialog>();
    struct Dialog {
        SpeakerSprite Img;
        string Name;
        string Text;
        bool openCombat;
        
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
        public Dialog(SpeakerSprite img,string name, string text,bool InCombat)
        {
            this.openCombat = InCombat;
            this.Img = img;
            this.Name = name;
            this.Text = text;
        
        }
    
    
    }

    // Start is called before the first frame update
    void Start()
    {
      //  AddDialog(StartingDialog,false);
       // AddDialog(precombatDialog,false);
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    private void LateUpdate()
    {
         if (dialogs.Count > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextLine();
            }
        }
     
    }


    public void setRoundText(string Text)
    {

        dialogTextBox.text = Text;
    }

    public void AddDialog(string Text, bool incombat)
    {

        SpeakerSprite image = SpeakerSprite.none;
        string Name = null;
        string text = Text;
        Dialog dialog = new Dialog(image, Name, text, incombat);

        dialogs.Add(dialog);
        //endLine = false;
        dialogTextBox.text = dialogs[0].getText();

    }

    public void AddDialogList(DialogList dialogeList, bool incombat)
    {
      
        for (int x = 0; x < dialogeList.dialogs.Count; x++)
        {
            SpeakerSprite image = SpeakerSprite.none;
            string Name=dialogeList.dialogs[x].getSpeaker();
            string text=dialogeList.dialogs[x].getDialog();
            Dialog dialog = new Dialog(image, Name, text,incombat);

            dialogs.Add(dialog);
           
        }
        // endLine = false;
        LevelScript.instance.setCombatPanelActive(dialogs[0].GetIsOpenInCombat());
        dialogTextBox.text = dialogs[0].getText();

    }



    public void NextLine()
    {


        Debug.Log("");

        dialogs.RemoveAt(0);

        if (dialogs.Count > 0)
        {
            dialogTextBox.text = dialogs[0].getText();
        }

        else
        {
            LevelScript.instance.onDialogEnd();
        }



    }
}
