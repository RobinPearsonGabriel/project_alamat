using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu]
public class DialogList : ScriptableObject
{
  public List <Dialog> dialogs;
    [System.Serializable]
    public struct Dialog
    {
        public string sentence;
        public string speaker;

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
