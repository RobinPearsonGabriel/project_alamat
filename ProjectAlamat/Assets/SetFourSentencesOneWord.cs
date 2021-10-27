using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFourSentencesOneWord : MonoBehaviour
{

   [SerializeField] FourPicOneWord_Wheel fourSentencesOneWord_script;
    [SerializeField] List<Text> Sentences;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSenctences(Salita salita, List<string> words)
    {


        for (int i = 0; i < Sentences.Count; i++)
        {
            Sentences[i].text = salita.Sentences[i];
        }
        int rand = Random.Range(0, 2);

        fourSentencesOneWord_script.setchoices(words);
      
           
        
    
    }
   void SetAnswer()
    { 
    
    
    }

}
