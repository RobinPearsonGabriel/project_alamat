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
    [SerializeField] List<Button> choiceButtons;

    List<Salita> LearningPhaseWords = new List<Salita>();

    // Start is called before the first frame update
    int round=0;
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


    void RandmizeList( ref List<Salita>list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Salita temp;

            int rand = Random.Range(0, list.Count);
            temp= list[i];
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
                    break;
                }
               
            }













        //choices.Clear();

    }


    void LearningPhaseGame()
    {
        if (LearningPhaseWords.Count > 0)
        {


            List<Salita> choices = new List<Salita>();
            Currentword = LearningPhaseWords[Random.Range(0, LearningPhaseWords.Count)];
            choices.Add(Currentword);
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < wordList.Count; y++)
                {
                    if (!choices.Contains(wordList[y]))
                    {
                        choices.Add(wordList[y]);
                        break;
                    }

                }

            }

            RandmizeList(ref choices);


            dialogTextBox.text= "Filipino : "+ Currentword.tagalogSentenceTraining + "\n" +"English :" +Currentword.englishSentenceTraining;


        }
        else
        {
            currentPhase = roundPhase.Combat;
            CombatPhaseGame();
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
                

            }
        }
    }

    public void EnterPressed(TextMeshProUGUI text)
    {
        
    }



}
