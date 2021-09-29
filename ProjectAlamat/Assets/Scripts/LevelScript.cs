using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public enum roundPhase { Learning, Combat,Win, Lose };

public class LevelScript : MonoBehaviour
{
    Question_Script question_Script;
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

  

  public  roundPhase currentPhase;
    //  public enum characterType { player, enemy };
    SetChoiceBox choiceboxes;
    [SerializeField] GameObject nextButton;
     [SerializeField] DialogList StartingDialog;
    [SerializeField] DialogList precombatDialog;
    [SerializeField] DialogList VictoryDialog;
    [SerializeField] DialogList DefeatDialog;
    [SerializeField] List<Salita> wordList = new List<Salita>();
    // [SerializeField] GameObject QuestionDialogText;
    [SerializeField] TMP_InputField PlayerInputBox;
    [SerializeField] TextMeshProUGUI dialogTextBox;
    Salita Currentword;
    [SerializeField] GameObject Trainingphasepanel;
   // [SerializeField] List<TextMeshProUGUI> choicesTextboxText;
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject enemyObj;
 public       List<Salita> LearningPhaseWords = new List<Salita>();
    [SerializeField] GameObject learningPhasePanel;
    [SerializeField] GameObject combatPhasePanel;
    [SerializeField] GameObject statsPanel;
    PlayerScript player;
    EnemyScript enemy;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject VictoryPanel;
    List<string> currentDialog = new List<string>();
    bool isStarting;
    // Start is called before the first frame update
    int round ;
    int totalRounds;
    bool canAnswer;

    void Start()
    {
        question_Script = GetComponent<Question_Script>();
        choiceboxes = FindObjectOfType<SetChoiceBox>();
        isStarting = true;
        enemyObj.SetActive(false);
       // enemy = enemyObj.GetComponent<EnemyScript>();
       //player = playerObj.GetComponent<PlayerScript>();
        combatPhasePanel.SetActive(false);
        statsPanel.SetActive(false);
        learningPhasePanel.SetActive(false);
        enemyObj.SetActive(false);
        currentPhase = roundPhase.Learning;



        RandmizeList(ref wordList);
        totalRounds = wordList.Count;

        DialogStart(StartingDialog);
  
    }

    // Update is called once per frame
    void Update()
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


   

    void DialogStart(DialogList dialogeList)
    {

        learningPhasePanel.SetActive(false);
        statsPanel.SetActive(false);
        combatPhasePanel.SetActive(false);
        for (int x=0;x< dialogeList.dialogs.Count;x++)
        {
            currentDialog.Add(dialogeList.dialogs[x].getDialog());
        }
        dialogTextBox.text = currentDialog[0];
        canAnswer = false;

        nextButton.SetActive(true);

    }


  public  void NextLine()
    {
       
        Debug.Log("");
        if (currentDialog.Count > 1)
        {
            currentDialog.RemoveAt(0);
            dialogTextBox.text = currentDialog[0];
            
        }
        else
        {
            
            switch (currentPhase)
            {
                case roundPhase.Learning:
                    if (!canAnswer)
                    {
                        LearningPhaseSetUp();
                    }
                    else
                    {
                        LearningPhaseGame();
                    }
                    break;
                case roundPhase.Combat:
                    if (!canAnswer)
                    {
                        CombatPhasSetup();
                    }
                    else
                    {
                        CombatPhaseGame();
                    }
                    break;
                case roundPhase.Win:
                    VictoryPanel.SetActive(true);

                    float currExp = player.getCurrentExp();

                    VictoryPanel.GetComponent<showPlayerprogress>().expbareffect(player.getCurrentExp(), player.GetExpToLevel(), enemy.GetExperincePoint());

                    player.gainExp(enemy.GetExperincePoint());
                    break;
                case roundPhase.Lose:
                    GameOverPanel.SetActive(true);
                    break;
            
            }
        }

    
    }

 void LearningPhaseSetUp()
    {


        round = 5;
        round = Mathf.Min(round, wordList.Count);
        currentPhase = roundPhase.Learning;
        combatPhasePanel.SetActive(false);
      
        enemyObj.SetActive(false);
        RandmizeList(ref wordList);
        for (int x = 0; x < wordList.Count; x++)
        {
            if (!LearningPhaseWords.Contains(wordList[x]))
            {
                LearningPhaseWords.Add(wordList[x]);
            
            
            }

        }
        //choices.Clear();
      
        LearningPhaseGame();
    }

    void LearningPhaseGame()
    {
       
        if (round>0)
        {

           
            nextButton.SetActive(false);
            learningPhasePanel.SetActive(true);
            canAnswer = true;
            //setChoices
            //List<Salita> choices = new List<Salita>();
            //Currentword = LearningPhaseWords[Random.Range(0, LearningPhaseWords.Count)];
            //choices.Add(Currentword);
            //for (int x = 1; x < 4; x++)
            //{ 
            //   for(int i= 0; i<wordList.Count;i++)
            //    { 
             
            //        if (!choices.Contains(wordList[i]))
            //        {
            //            choices.Add(wordList[i]);
            //            break;
            //        }
            //    }
            //}

          //  RandmizeList(ref choices);
            ////Randomize Choices
            //for (int i = 0; i < choices.Count; i++)
            //{
            //   Salita temp;

            //     int rand = Random.Range(0, choices.Count-1);
            //    temp = choices[i];
            //     choices[i] = choices[rand];
            //    choices[rand] = temp;
            // }


          //choiceboxes.setSalita(choices);
            //SetchoiceboxText(choices);
            dialogTextBox.text = question_Script.multipleChooiceQuestion();

           // choices.Clear();
        }
        else
        {
            enemyObj.SetActive(true);
            currentPhase = roundPhase.Combat;
            DialogStart(precombatDialog);
        }



    }


    //assing string to 
    
   void CombatPhasSetup()
    {

        currentPhase = roundPhase.Combat;
        enemyObj.SetActive(true);
        enemy = enemyObj.GetComponent<EnemyScript>();
        player = playerObj.GetComponent<PlayerScript>();
        combatPhasePanel.SetActive (true);
        statsPanel.SetActive(true);
        learningPhasePanel.SetActive( false);
       
        CombatPhaseGame();
    }
    void CombatPhaseGame()
    {
        nextButton.SetActive(false);
        combatPhasePanel.SetActive(true);
        canAnswer = true;
        //    int rand = Random.Range(0,wordList.Count);
        //    Currentword = wordList[rand];


        //    dialogTextBox.text = "Filipino : " + Currentword.tagalogSentenceTraining + "\n" + "English :" + Currentword.englishSentenceTraining;
        dialogTextBox.text = question_Script.Identification();

    }



    public void result(bool isCorrect)
    {
        if (canAnswer)
        {
            //correct answer
            if (isCorrect)
            {
                Debug.Log("Answer was correct");
                dialogTextBox.text = " Tama!";
                combatPhasePanel.SetActive(false);
                learningPhasePanel.SetActive(false);
                nextButton.SetActive(true);
              
             
                    //  round++;
                    if (currentPhase == roundPhase.Learning)
                    {
                    //   LearningPhaseWords.Remove(Currentword);
                    //LearningPhaseGame();
                    round--;

                    }
                    else if (currentPhase == roundPhase.Combat)
                    {
                        Debug.Log("Correct");
                        player.AtkPercentIncrease(1.0f,enemyObj);

                        dialogTextBox.text = "Player Hit Enemy";
                        if (enemy.IsAlive())
                        {

                            //CombatPhaseGame();
                        }
                        else
                        {

                          
                        }
                    }
                
            }
            //incorrect

            else
            {
                dialogTextBox.text = " Mali!";
                combatPhasePanel.SetActive(false);
                learningPhasePanel.SetActive(false);
                nextButton.SetActive(true);
            
                    if (currentPhase == roundPhase.Learning)
                    {

                        //LearningPhaseGame();

                    }
                    else if (currentPhase == roundPhase.Combat)
                    {

                        //CombatPhaseGame();
                    }
                
            }
            if (currentPhase == roundPhase.Combat&& enemy!=null)
            {
                enemy.Attack(playerObj);
            }
        }
    }
    //on playerchoices picked
    public void ChoicePressed(TextMeshProUGUI text)
    {
        if (currentPhase == roundPhase.Learning)
        {
            //CheckAnswer(text.text);
            Debug.Log(text.text);
        }
    }

    public void EnterPressed(TMP_InputField answer)
    {
        if (currentPhase == roundPhase.Combat)
        {
         
            
            Debug.Log(answer.text);
        }
    }

    public void Victory()
    {
        currentPhase = roundPhase.Win;
        DialogStart(VictoryDialog);
    }

    public void GameOver()
    {
        currentPhase = roundPhase.Lose;
        DialogStart(DefeatDialog);

    }

}
