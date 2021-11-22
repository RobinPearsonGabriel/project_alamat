using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWheelSentences : MonoBehaviour
{
    [SerializeField] spinner spinner;
    [SerializeField] List<Text> OuterPhrases;
    [SerializeField] List<Text> InnerPhrases;
     List<string> OuterEng=new List<string>();
    List<string> OuterTagalog= new List<string>();
    bool isTranslated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Translate()
    {
        isTranslated = !isTranslated;
        for (int i = 0; i < 3; i++)
        {
            if (isTranslated)
            {
                OuterPhrases[i].text = OuterEng[i];
            }
            else
            {
                OuterPhrases[i].text = OuterTagalog[i];
            }
        }
    }

    public void SetPhrases(List<Salita> Salitas)
    {
        isTranslated = false;
      
        OuterEng.Clear();
        OuterTagalog.Clear();
        List<Salita> wordsUsed = new List<Salita>();
        for (int i = 0; i < 3; i++ )
        {
            int x = Random.Range(0, Salitas.Count);
            if (!wordsUsed.Contains(Salitas[x]))
            {
                wordsUsed.Add(Salitas[x]);

                OuterPhrases[i].text = Salitas[x].englishSentenceTraining;
                OuterEng.Add(Salitas[x].englishSentenceTraining);
                OuterTagalog.Add(Salitas[x].tagalogSentenceTraining);
                InnerPhrases[i].text = Salitas[x].salita;
            }
            else{
                Debug.Log("Duplicate Question rechecking");
                i--;
            }
        }

        spinner.offsetStart();
    }

}
