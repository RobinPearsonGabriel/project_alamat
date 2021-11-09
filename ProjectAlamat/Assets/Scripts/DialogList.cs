using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu]
public class DialogList : ScriptableObject
{

    public enum Speaker { Andes, Enemy,Ibneng,NoOneSpeaking  };
    public enum Pos { farleft, closeleft, closeright, farright };
    public List <Dialog> dialogs;
   

    [System.Serializable]
    public struct Dialog
    {
        public Speaker speakerSprite;

        public Pos pos;
        public string sentence;
        public string speaker;
        public int Bg;


       //0-Andes 2-
       public int speakerNumber;

        public string getDialog()
        {
            return sentence;

        }

        public string getSpeaker()
        {
            return speaker;
        }
}


}
