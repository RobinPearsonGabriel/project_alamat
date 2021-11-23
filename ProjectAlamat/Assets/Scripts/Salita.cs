using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class Salita : ScriptableObject
{

 
    // Start is called before the first frame update
    public string salita;
    public string description;
    
    //in training question
    [Header("In Training Question")]
    public string tagalogSentenceTraining;
    public string englishSentenceTraining;

    [Header(" Question")]
    public string tagalogSentenceBattle;
    public string englishSentenceBattle;

   public List<string> Sentences;
}
