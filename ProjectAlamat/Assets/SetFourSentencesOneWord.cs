using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFourSentencesOneWord : MonoBehaviour
{

    [SerializeField] List<Text> Sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSenctences(Salita salita)
    {
        Debug.Log("HI");
        int rand;
        foreach (Text sentence in Sentences)
        {
            rand = Random.Range(0, 2);
            if (rand >= 1)
            {
                sentence.text = salita.tagalogSentenceTraining;
            }
            else
            {
                sentence.text = salita.englishSentenceTraining;
            }
           
        }
    
    }


}
