using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFourSentencesOneWord : MonoBehaviour
{
    [SerializeField] List<Text> Choices;
    [SerializeField] List<Text> Sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSenctences(Salita salita, string word)
    {


        for (int i = 0; i < Sentences.Count; i++)
        {
            Sentences[i].text = salita.Sentences[i];
        }
        int rand = Random.Range(0, 2);

        if (rand == 1)
        {
            Choices[0].text = salita.salita;
            Choices[1].text = word;
        }
        else
        {
            Choices[1].text = salita.salita;
            Choices[0].text = word;


        }
      
           
        
    
    }


}
