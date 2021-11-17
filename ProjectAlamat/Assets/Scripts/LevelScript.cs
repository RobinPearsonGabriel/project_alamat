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
    Dialog_Script dialog_Script;
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
    //   [SerializeField] TextMeshProUGUI dialogTextBox;
    //  Salita Currentword;

    // [SerializeField] List<TextMeshProUGUI> choicesTextboxText;
    public GameObject playerObj;
    public GameObject enemyObj;
    public GameObject Indicator;
    public Sprite correctImage;
    public Sprite wrongImage;
    public List<Salita> LearningPhaseWords = new List<Salita>();
    [SerializeField] GameObject combatPhasePanel;
    public GameObject statsPanel;
    PlayerScript player;
    EnemyScript enemy;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject VictoryPanel;
    List<string> currentDialog = new List<string>();
    // bool isStarting;
    // Start is called before the first frame update

    public Image enemyFaceImage;
    public Image playerFaceImage;

    [Header("TutorialPanel")]
    public GameObject tutorialPanel;
    bool tutorialComplete = false;

    [Header("GameOverPanel")]
    public Image enemyImage;
    public Text enemyName;
    public Text enemyDefeatDialog;
    int round ;
    int totalRounds;
    bool canAnswer;
    
    public void setCanAnswer(bool x)
    {
        canAnswer = x;
    }
    public bool getCanAnswer()
    {
      return  canAnswer;
    }


    public void TutorialCheck()
    {
        if (!tutorialComplete)
        {
            tutorialPanel.SetActive(true);
        }
    }

    void Start()
    {
        dialog_Script = GetComponent<Dialog_Script>();
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

        dialog_Script.AddDialogList(StartingDialog,false);
        dialog_Script.AddDialogList(precombatDialog,false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void completeTutorial(bool finished)
    {
        tutorialComplete = finished;
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




    //void DialogStart(DialogList dialogeList)
    //{


    //    statsPanel.SetActive(false);
    //    combatPhasePanel.SetActive(false);
    //    for (int x=0;x< dialogeList.dialogs.Count;x++)
    //    {
    //        currentDialog.Add(dialogeList.dialogs[x].getDialog());
    //    }
    //    dialogTextBox.text = currentDialog[0];
    //    canAnswer = false;

    //    nextButton.SetActive(true);

    //}

    public QuestionType GetQuestionType()
    {
        return questionType;
    }
  public void onDialogEnd()
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
                enemy.DeactivateSkill();
                float currExp = player.getCurrentExp();

                VictoryPanel.GetComponent<showPlayerprogress>().expbareffect(player.getCurrentExp(), player.GetExpToLevel(), enemy.GetExperincePoint());

                player.gainExp(enemy.GetExperincePoint());
                break;
            case roundPhase.Lose:
                GameOverPanel.SetActive(true);
                break;

        }



    }




    //assing string to 

    void CombatPhasSetup()
    {

        currentPhase = roundPhase.Combat;
        enemyObj.SetActive(true);
        enemy = enemyObj.GetComponent<EnemyScript>();
        player = playerObj.GetComponent<PlayerScript>();
        playerFaceImage.gameObject.SetActive(true);
        enemyFaceImage.gameObject.SetActive(true);
        playerFaceImage.sprite = player.GetFaceImage();
        playerFaceImage.SetNativeSize();
        enemyFaceImage.sprite = enemy.GetFaceImage();
        enemyFaceImage.SetNativeSize();
        //playerFaceImage.SetNativeSize();
        //enemyFaceImage.SetNativeSize();
        combatPhasePanel.SetActive (true);
        statsPanel.SetActive(true);
        
       
        CombatPhaseGame();
    }
    void CombatPhaseGame()
    {
        statsPanel.SetActive(true);
        combatPhasePanel.SetActive(true);
        canAnswer = true;
        playerObj.GetComponent<SpriteRenderer>().color = Color.white;
        enemyObj.GetComponent<SpriteRenderer>().color = Color.white;
        dialog_Script.setRoundText (question_Script.GameStart(questionType),enemy.getName());

    }
    public void setCombatPanelActive(bool isActive)
    {
        combatPhasePanel.SetActive(isActive);
    }


    public void result(bool isCorrect)
    {
        if (canAnswer)
        {
            combatPhasePanel.SetActive(false);
            //correct answer
            if (isCorrect)
            {
                Indicator.GetComponent<Image>().sprite = correctImage;
                Indicator.SetActive(true);

                Debug.Log("Answer was correct");
                dialog_Script.AddDialog(player.GetCombatDialog(),false,player.getName(),Dialog_Script.SpeakerSprite.Andes,DialogList.Speaker.Andes,DialogList.Pos.farleft );
                

                combatPhasePanel.SetActive(false);
               
               
              
             
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
                    if (player.AtkPercentIncrease(1.0f, enemyObj))
                    {
                        dialog_Script.AddDialog(player.getName() + " hit "+ enemy.getName() + "! ", false, " ", Dialog_Script.SpeakerSprite.Enemy,DialogList.Speaker.Enemy,DialogList.Pos.farleft);
                    }

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

                Indicator.GetComponent<Image>().sprite = wrongImage;
                Indicator.SetActive(true);
                dialog_Script.AddDialog ( enemy.GetCombatDialog(), false,enemy.getName(), Dialog_Script.SpeakerSprite.Enemy,DialogList.Speaker.Enemy,DialogList.Pos.farright);
                combatPhasePanel.SetActive(false);
               
                
            
                     if (currentPhase == roundPhase.Combat)
                    {

                        //CombatPhaseGame();
                    }
                
            }
            if (currentPhase == roundPhase.Combat&& enemy!=null)
            {
                if (enemy.Attack(playerObj))
                {
                    dialog_Script.AddDialog(enemy.getName() + " hit Andres!", false, " ", Dialog_Script.SpeakerSprite.Enemy,DialogList.Speaker.Andes,DialogList.Pos.farright);
                }
            }
        }
    }
    //on playerchoices picked




    public void Victory()
    {
        statsPanel.SetActive(false);
        this.gameObject.GetComponent<ActionsScript>().ActivateWinPanel();
        foreach  (string text in wordsLearned)
        {
            wordsLearnedText.text +="\n"+ text;
        }
        dialog_Script.AddDialogList(VictoryDialog,true);
        playerObj.transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -5);
        enemyObj.transform.position = new Vector3(enemyObj.transform.position.x, enemyObj.transform.position.y, -5);
        //NextLine();
        currentPhase = roundPhase.Win;
    }

    public void GameOver()
    {
        enemyImage.sprite = enemy.GetFaceImage();
        enemyImage.SetNativeSize();
        enemyName.text = enemy.getName();
        enemyDefeatDialog.text = enemy.GetDefeatDialog();
        currentPhase = roundPhase.Lose;
        dialog_Script.AddDialogList(DefeatDialog,true);
      
    }

}
