using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFourSentencesOneWord : MonoBehaviour
{

<<<<<<< HEAD
   [SerializeField] FourPicOneWord_Wheel fourSentencesOneWord_script;
=======
>>>>>>> b8c1b61e4de600620d48bcea4dcc991ed974810a
    [SerializeField] List<Text> Sentences;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< HEAD
    public void SetSenctences(Salita salita, List<string> words)
=======
    public void SetSenctences(Salita salita)
>>>>>>> b8c1b61e4de600620d48bcea4dcc991ed974810a
    {
        Debug.Log("HI");
        int rand;
        foreach (Text sentence in Sentences)
        {
<<<<<<< HEAD
            Sentences[i].text = salita.Sentences[i];
        }
        int rand = Random.Range(0, 2);

        fourSentencesOneWord_script.setchoices(words);
      
=======
            rand = Random.Range(0, 2);
            if (rand >= 1)
            {
                sentence.text = salita.tagalogSentenceTraining;
            }
            else
            {
                sentence.text = salita.englishSentenceTraining;
            }
>>>>>>> b8c1b61e4de600620d48bcea4dcc991ed974810a
           
        }
    
    }
   void SetAnswer()
    { 
    
    
    }

}
