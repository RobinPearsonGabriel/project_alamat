using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public enum roundPhase { Learning, Combat };
public class LevelScript : MonoBehaviour
{

    public static LevelScript instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }



    roundPhase currentPhase;
    public enum characterType { player, enemy };
    [SerializeField] List<Salita> wordList = new List<Salita>();
    // [SerializeField] GameObject QuestionDialogText;
    [SerializeField] TMP_InputField PlayerInputBox;
    [SerializeField] TextMeshProUGUI dialogTextBox;
    Salita Currentword;
    [SerializeField] GameObject Trainingphasepanel;
    [SerializeField] List<TextMeshProUGUI> choicesTextboxText;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    public List<Salita> LearningPhaseWords = new List<Salita>();

    // Start is called before the first frame update
    int round = 0;
    int totalRounds;
    void Start()
    {
        currentPhase = roundPhase.Learning;

        RandmizeList(ref wordList);
        totalRounds = wordList.Count;
        LearningPhaseSetUp();
        LearningPhaseGame();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void RandmizeList(ref List<Salita> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Salita temp;

            int rand = Random.Range(0, list.Count);
            temp = list[i];
            list[i] = wordList[rand];
            list[rand] = temp;
        }

    }


    void LearningPhaseSetUp()
    {
        RandmizeList(ref wordList);
        for (int x = 0; x < wordList.Count; x++)
        {
            if (!LearningPhaseWords.Contains(wordList[x]))
            {
                LearningPhaseWords.Add(wordList[x]);
              //  break;
            }

        }
        //choices.Clear();

    }


    void LearningPhaseGame()
    {
        if (LearningPhaseWords.Count > 0)
        {

            //setChoices
            List<string> choices = new List<string>();
            Currentword = LearningPhaseWords[Random.Range(0, LearningPhaseWords.Count)];
            choices.Add(Currentword.salita);
            for (int x = 1; x < 4; x++)
            { 
               for(int i= 0; i<wordList.Count;i++)
                { 
             
                    if (!choices.Contains(wordList[i].salita))
                    {
                        choices.Add(wordList[i].salita);
                        break;
                    }
                }
            }

           // RandmizeList(ref choices);
           ////Randomize Choices
           for (int i = 0; i < choices.Count; i++)
           {
               string temp;

                int rand = Random.Range(0, choices.Count-1);
               temp = choices[i];
                choices[i] = choices[rand];
               choices[rand] = temp;
            }



            SetchoiceboxText(choices);
            dialogTextBox.text = "Filipino : " + Currentword.tagalogSentenceTraining + "\n" + "English :" + Currentword.englishSentenceTraining;

           // choices.Clear();
        }
        else
        {
            currentPhase = roundPhase.Combat;
            CombatPhaseGame();
        }



    }


    //assing string to 
    void SetchoiceboxText(List<string> salitas)
    {
        for (int i = 0; i < choicesTextboxText.Count; i++)
        {
            if (choicesTextboxText[i].text != null )
            choicesTextboxText[i].text = salitas[i];
        }

    }

    void CombatPhaseGame()
    {


    
    }



    public void CheckAnswer(string Answer)
    {
        if (Currentword.salita.ToLower() == Answer.ToLower())
        {
            round++;
            if (currentPhase == roundPhase.Learning)
            {
                LearningPhaseWords.Remove(Currentword);
                LearningPhaseGame();
   if(Enemy!=null)
                Player.GetComponent<PlayerScript>().Attack(Enemy);
            }
            else
            {
             
            }
        }
        else
        {
            if (currentPhase == roundPhase.Learning)
            {
               //LearningPhaseWords.Remove(Currentword);
                LearningPhaseGame();

            }
            // takedamage
        }

        if (currentPhase == roundPhase.Combat)
        { 
        
        }

    }
    //on playerchoices picked
    public void ChoicePressed(TextMeshProUGUI text)
    {
        CheckAnswer(text.text);

    }



}
