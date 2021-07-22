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
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject enemyObj;
     List<Salita> LearningPhaseWords = new List<Salita>();
    [SerializeField] GameObject learningPhasePanel;
    [SerializeField] GameObject combatPhasePanel;
    PlayerScript player;
    EnemyScript enemy;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject VictoryPanel;
    // Start is called before the first frame update
    int round = 0;
    int totalRounds;
    void Start()
    {
        currentPhase = roundPhase.Learning;

        RandmizeList(ref wordList);
        totalRounds = wordList.Count;
        LearningPhaseSetUp();
        
        //CombatPhasSetup();
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
        combatPhasePanel.SetActive(false);
        learningPhasePanel.SetActive(true);
        enemyObj.SetActive(false);
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
         LearningPhaseGame();
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
            CombatPhasSetup();
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
   void CombatPhasSetup()
    {
        currentPhase = roundPhase.Combat;
        enemyObj.SetActive(true);
        enemy = enemyObj.GetComponent<EnemyScript>();
        player = playerObj.GetComponent<PlayerScript>();
        combatPhasePanel.SetActive (true);
        learningPhasePanel.SetActive( false);
        enemyObj.SetActive(true);
        CombatPhaseGame();
    }
    void CombatPhaseGame()
    {
        int rand = Random.Range(0,wordList.Count);
        Currentword = wordList[rand];
        dialogTextBox.text = "Filipino : " + Currentword.tagalogSentenceTraining + "\n" + "English :" + Currentword.englishSentenceTraining;


    }



    public void CheckAnswer(string Answer)
    {
        //correct answer
        if (Currentword.salita.ToLower() == Answer.ToLower())
        {
          //  round++;
            if (currentPhase == roundPhase.Learning)
            {
                LearningPhaseWords.Remove(Currentword);
                LearningPhaseGame();
  
               
            }
            else
            {
                Debug.LogError("Correct");
                player.Attack(enemyObj);
                if (enemy.IsAlive())
               {
                   CombatPhaseGame();
               }
                else
                {

                    enemy.GetExperincePoint();
                }
            }
        }
        //incorrect
        else
        {
            if (currentPhase == roundPhase.Learning)
            {
                LearningPhaseWords.Remove(Currentword);
                LearningPhaseGame();

            }
            else 
            {

                CombatPhaseGame();
            }
        }
       if (currentPhase == roundPhase.Combat)
       {
           enemy.Attack(playerObj);
       }

    }
    //on playerchoices picked
    public void ChoicePressed(TextMeshProUGUI text)
    {
        CheckAnswer(text.text);
        Debug.Log(text.text);

    }

    public void EnterPressed(TMP_InputField answer)
    {
        CheckAnswer(answer.text);
        Debug.Log(answer.text);

    }

    public void Victory(float exp)
    {
        VictoryPanel.SetActive(true);

        float currExp = player.getCurrentExp();

  VictoryPanel.GetComponent<showPlayerprogress>().expbareffect(player.getCurrentExp(),player.GetExpToLevel(),exp);

        player.gainExp(exp);
      
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

}
