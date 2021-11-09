using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum QuestionType { Identification, Choices,ScrollWheel, ngNang, rinDin, Image, wheelGame,FourSentenceOneWord};
public class Question_Script : MonoBehaviour
{
   // [SerializeField] GameObject FourSentecesOnewordPanel;
    [SerializeField] GameObject IdentificationPanel;
    [SerializeField] GameObject ChoicesPanel;
    [SerializeField] GameObject ScrollwheelPanel;
    [SerializeField] GameObject FourSentecesOnewordPanel;

    [SerializeField]  SetChoiceBox setChoiceBox;
    [SerializeField] ScrollScript scrollScript;
 [SerializeField]   SetWheelSentences setWheelSentences_scrpt;
    [SerializeField] GameObject wheelGamePanel;
   

    [SerializeField] SetFourSentencesOneWord fourSentencesOneWord;
   [SerializeField] List<Salita> wordList= new List<Salita>();
    Salita Answer;
    [SerializeField] GameObject BookPanel;
    [SerializeField] TextMeshProUGUI BookQuestion;
 
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    QuestionType questionType;
   

  public  Salita GetSalita()
    {


        if (Answer != null)
        {
            Debug.Log(Answer.salita);
            return Answer;
        }

        return null;



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
                wheelGamePanel.SetActive(false);
                ScrollwheelPanel.SetActive(false);
                 FourSentecesOnewordPanel.SetActive(false);
                BookPanel.SetActive(true);
                BookQuestion.text = Identification();
                break;
            case QuestionType.Choices:
                IdentificationPanel.SetActive(false);
                ChoicesPanel.SetActive(true);
                wheelGamePanel.SetActive(false);
                ScrollwheelPanel.SetActive(false);
                FourSentecesOnewordPanel.SetActive(false);
                BookPanel.SetActive(true);
                BookQuestion.text = multipleChooiceQuestion();
                break;
            case QuestionType.wheelGame:
                wheelGamePanel.SetActive(true);
                IdentificationPanel.SetActive(false);
                ChoicesPanel.SetActive(false);
                ScrollwheelPanel.SetActive(false);
                FourSentecesOnewordPanel.SetActive(false);
                BookPanel.SetActive(false);
                qText = wheelGame();
                break;

            case QuestionType.FourSentenceOneWord:
                BookPanel.SetActive(false);
                IdentificationPanel.SetActive(false);
                ChoicesPanel.SetActive(false);
                wheelGamePanel.SetActive(false);
                ScrollwheelPanel.SetActive(false);
                 FourSentecesOnewordPanel.SetActive(true);

             SetFourSentencesOneWord();
                qText = "";
                break;
            case QuestionType.ScrollWheel:
                IdentificationPanel.SetActive(false);
                ChoicesPanel.SetActive(false);
                wheelGamePanel.SetActive(false);
                ScrollwheelPanel.SetActive(true);
                BookPanel.SetActive(false);
                ScrollWheel();
                qText = "";
                 FourSentecesOnewordPanel.SetActive(false);

                // qText= SetFourSentencesOneWord();
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

             int random = Random.Range(0, choices.Count);
            temp = choices[i];
             choices[i] = choices[random];
            choices[random] = temp;
         }

        setChoiceBox.setSalita(choices);
        return "English :" + Answer.englishSentenceTraining +"\n" + "Filipino : " + Answer.tagalogSentenceTraining;
    }

    public string Identification( )
    {
        Answer = wordList[Random.Range(0, wordList.Count)];

        return "English :" + Answer.englishSentenceTraining +"\n" + "Filipino : " + Answer.tagalogSentenceTraining;


    }



    public void SetFourSentencesOneWord()
    {
       
      
        List<string> choices = new List<string>();
        Answer = wordList[Random.Range(0, wordList.Count-1)];

        choices.Add(Answer.salita);

        for (int i = 0; i < 4; i++)
        {

            for (int y = 0; y < wordList.Count; y++)
            {

                if (!choices.Contains(wordList[i].salita))
                {
                    choices.Add(wordList[i].salita);
                    break;
                }
            }



        }
        for (int i = 0; i < choices.Count-1; i++)
        {
            string temp;

            int random = Random.Range(0, choices.Count);
            temp = choices[i];
            choices[i] = choices[random];
            choices[random] = temp;
        }
        Debug.LogWarning(choices.Count);
        fourSentencesOneWord.SetSenctences(Answer,choices);


    }


    public string wheelGame()
    {

        List<Salita> phrases = new List<Salita>();

        
        for (int x = 1; x < wordList.Count; x++)
        {
            for (int i = 0; i < wordList.Count; i++)
            {

                if (!phrases.Contains(wordList[i]))
                {
                    phrases.Add(wordList[i]);
                    break;
                }
            }
        }
        
        

        setWheelSentences_scrpt.SetPhrases(phrases);
        return "Match the sentences ";
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

    void RandmizeList(ref List<string> list)
    {
        string temp;
        for (int i = 0; i < list.Count; i++)
        {


            int rand = Random.Range(0, list.Count);



            temp = list[i];
            list[i] = wordList[rand].salita;
            list[rand] = temp;

        }

    }


    //typedquestion
    //checker

    public int Getwordlistcount()
    {
        return wordList.Count;
    }


    void ScrollWheel()
    {
        List<string> texts = new List<string>(); 
        Answer = wordList[Random.Range(0, wordList.Count)];
        texts.Add(Answer.salita);
        for (int x = 1; x < 3; x++)
        {
            for (int i = 0; i < wordList.Count; i++)
            {

                if (!texts.Contains(wordList[i].salita))
                {
                    texts.Add(wordList[i].salita);
                    break;
                }
            }
        }

        string temp;
        //randomize 
        for (int i = 0; i < texts.Count; i++)
        {


            int rand = Random.Range(0, texts.Count);



            temp = texts[i];
            texts[i] = texts[rand];
            texts[rand] = temp;

        }

    



    scrollScript.setTexts(Answer.tagalogSentenceTraining, texts);

    }





    // Update is called once per frame
    //string SetFourSentencesOneWord()
    //{
    //    Answer = wordList[Random.Range(0, wordList.Count)];

    //    fourSentencesOneWord.SetSenctences(Answer);
    //    return "";
    //}




}
