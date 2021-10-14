using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public enum roundPhase {  Combat,Win, Lose };

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
   [ SerializeField] QuestionType questionType;

  [SerializeField]  Text wordsLearnedText;
  public  roundPhase currentPhase;
    //  public enum characterType { player, enemy };
    SetChoiceBox choiceboxes;
    List<string> wordsLearned;
    [SerializeField] GameObject nextButton;
     [SerializeField] DialogList StartingDialog;
    [SerializeField] DialogList precombatDialog;
    [SerializeField] DialogList VictoryDialog;
    [SerializeField] DialogList DefeatDialog;
   // [SerializeField] List<Salita> wordList = new List<Salita>();
    // [SerializeField] GameObject QuestionDialogText;
    [SerializeField] TMP_InputField PlayerInputBox;
    [SerializeField] TextMeshProUGUI dialogTextBox;
  //  Salita Currentword;
  
   // [SerializeField] List<TextMeshProUGUI> choicesTextboxText;
    [SerializeField] GameObject playerObj;
    [SerializeField] GameObject enemyObj;
 public   List<Salita> LearningPhaseWords = new List<Salita>();
    
    [SerializeField] GameObject combatPhasePanel;
    [SerializeField] GameObject statsPanel;
    PlayerScript player;
    EnemyScript enemy;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject VictoryPanel;
    List<string> currentDialog = new List<string>();
   // bool isStarting;
    // Start is called before the first frame update
    int round ;
    int totalRounds;
    bool canAnswer;

    void Start()
    {
        wordsLearned = new List<string>();
        question_Script = GetComponent<Question_Script>();
        choiceboxes = FindObjectOfType<SetChoiceBox>();
     //   isStarting = true;
        enemyObj.SetActive(false);
       // enemy = enemyObj.GetComponent<EnemyScript>();
       //player = playerObj.GetComponent<PlayerScript>();
        combatPhasePanel.SetActive(false);
        statsPanel.SetActive(false);

        enemyObj.SetActive(false);
        currentPhase = roundPhase.Combat;

        CombatPhasSetup();

     //   RandmizeList(ref wordList);
      //  totalRounds = wordList.Count;

        DialogStart(StartingDialog);
        DialogStart(precombatDialog);
  
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
                list[i] = list[rand];
                list[rand] = temp;
            
        }

    }


   

    void DialogStart(DialogList dialogeList)
    {

      
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


  public void NextLine()
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




    //assing string to 
    
   void CombatPhasSetup()
    {

        currentPhase = roundPhase.Combat;
        enemyObj.SetActive(true);
        enemy = enemyObj.GetComponent<EnemyScript>();
        player = playerObj.GetComponent<PlayerScript>();
        combatPhasePanel.SetActive (true);
        statsPanel.SetActive(true);
        
       
        CombatPhaseGame();
    }
    void CombatPhaseGame()
    {
        nextButton.SetActive(false);
        combatPhasePanel.SetActive(true);
        canAnswer = true;

        dialogTextBox.text = question_Script.GameStart(questionType);

    }



    public void result(bool isCorrect)
    {
        if (canAnswer)
        {
            //correct answer
            if (isCorrect)
            {
               
                Debug.Log("Answer was correct");
                dialogTextBox.text = player.GetCombatDialog();
                combatPhasePanel.SetActive(false);
               
                nextButton.SetActive(true);
              
             
                    //  round++;
                
                    if (currentPhase == roundPhase.Combat)
                    {


                    if (question_Script.GetSalita() != null)
                    {
                        if (!wordsLearned.Contains(question_Script.GetSalita().salita))
                        {
                            wordsLearned.Add(question_Script.GetSalita().salita);
                        }
                    }
                        Debug.Log("Correct");
                        player.AtkPercentIncrease(1.0f,enemyObj);

                        //dialogTextBox.text = "Player Hit Enemy";
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
                dialogTextBox.text = enemy.GetCombatDialog();
                combatPhasePanel.SetActive(false);
               
                nextButton.SetActive(true);
            
                     if (currentPhase == roundPhase.Combat)
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




    public void Victory()
    {
        foreach  (string text in wordsLearned)
        {
            wordsLearnedText.text +="\n"+ text;
        }

        DialogStart(VictoryDialog);
        NextLine();
        currentPhase = roundPhase.Win;
    }

    public void GameOver()
    {
        currentPhase = roundPhase.Lose;
        DialogStart(DefeatDialog);
      
    }

}
