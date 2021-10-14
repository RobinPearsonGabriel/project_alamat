using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWheelSentences : MonoBehaviour
{
    [SerializeField] spinner spinner;
    [SerializeField] List<Text> OuterPhrases;
    [SerializeField] List<Text> InnerPhrases;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPhrases(List<Salita> Salitas)
    {
        List<Salita> wordsUsed = new List<Salita>();
        for (int i = 0; i < 3; i++ )
        {
            int x = Random.Range(0, Salitas.Count);
            if (!wordsUsed.Contains(Salitas[x]))
            {
                wordsUsed.Add(Salitas[x]);

                OuterPhrases[i].text = Salitas[x].englishSentenceTraining;
                InnerPhrases[i].text = Salitas[x].salita;
            }
        }

        spinner.offsetStart();
    }

}
