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

    public void SetPhrases(List<Salita>Salitas)
    {
        for (int i = 0; i < Salitas.Count;i++ )
        {
            OuterPhrases[i].text = Salitas[i].englishSentenceTraining;
            InnerPhrases[i].text = Salitas[i].salita;
        }

        spinner.offsetStart();
    }

}
