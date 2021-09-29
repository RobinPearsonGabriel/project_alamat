using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Question_Script : MonoBehaviour
{


  [SerializeField]  SetChoiceBox setChoiceBox;
   [SerializeField] List<Salita> wordList= new List<Salita>();
    Salita Answer;
 
    public enum questionType { Learning, Synonym,ngNang, rinDin,Image };
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public  Salita GetSalita()
    {
        Debug.Log(Answer.salita);
        return Answer;
    }

    //multipulechoice
    public string multipleChooiceQuestion()
    {
        int rand = Random.Range(0, wordList.Count);
        Answer = wordList[rand];
        List<Salita> choices = new List<Salita>();

        choices.Add(Answer);
        for (int x = 1; x < 4; x++)
        {
            for (int i = 0; i < wordList.Count; i++)
            {

                if (!choices.Contains(wordList[i]))
                {
                    choices.Add(wordList[i]);
                    break;
                }
            }
        }


        ////Randomize Choices
        for (int i = 0; i < choices.Count; i++)
        {
           Salita temp;

             int random = Random.Range(0, choices.Count-1);
            temp = choices[i];
             choices[i] = choices[random];
            choices[random] = temp;
         }

        setChoiceBox.setSalita(choices);
        return "Filipino : " + Answer.tagalogSentenceTraining + "\n" + "English :" + Answer.englishSentenceTraining;
    }

    public string Identification( )
    {
        Answer = wordList[Random.Range(0, wordList.Count)];

        return "Filipino : " + Answer.tagalogSentenceTraining + "\n" + "English :" + Answer.englishSentenceTraining;
      
    }


    public void FourPicOneWord()
    { 
    
    }

    void RandmizeList(ref List<Salita> list)
    {
        Salita temp;
        for (int i = 0; i < list.Count; i++)
        {


            int rand = Random.Range(0, list.Count);



            temp = list[i];
            list[i] = wordList[rand];
            list[rand] = temp;

        }

    }
    //typedquestion
    //checker








    // Update is called once per frame
    void Update()
    {
        
    }
    void LearningPhaseMode()
    { 
    
    
    }




}
