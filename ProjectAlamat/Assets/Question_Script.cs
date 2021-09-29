using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum QuestionType { Identification, Choices, ngNang, rinDin, Image };
public class Question_Script : MonoBehaviour
{

    [SerializeField] GameObject IdentificationPanel;
    [SerializeField] GameObject ChoicesPanel;
  [SerializeField]  SetChoiceBox setChoiceBox;
   [SerializeField] List<Salita> wordList= new List<Salita>();
    Salita Answer;
 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    QuestionType questionType;
   

  public  Salita GetSalita()
    {
        Debug.Log(Answer.salita);
        return Answer;


        if (questionType == QuestionType.Choices)
        { 
        
        
        }



    }


    public string GameStart(QuestionType type)
    {
        questionType = type;
        string qText="";
        switch (questionType)
        {
            case QuestionType.Identification:
                IdentificationPanel.SetActive(true);
                ChoicesPanel.SetActive(false);
                qText = Identification();
                break;
            case QuestionType.Choices:
                IdentificationPanel.SetActive(false);
                ChoicesPanel.SetActive(true);
                qText = multipleChooiceQuestion();
                break;
            case QuestionType.ngNang:
                break;
            case QuestionType.rinDin:
                break;
            case QuestionType.Image:
                break;
            default:
                break;


        }
        return qText;
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

   public int Getwordlistcount()
    {
        return wordList.Count;
    }






    // Update is called once per frame
    void Update()
    {
        
    }
    void LearningPhaseMode()
    { 
    
    
    }




}
