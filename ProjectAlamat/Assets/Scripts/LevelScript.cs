using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
  [SerializeField]  List<Salita> wordList = new List<Salita>();
    // Start is called before the first frame update
    int round=0;
    int totalRounds;
    void Start()
    {
        RandmizeList(ref wordList);
        totalRounds = wordList.Count;
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


    void LearningPhase()
    {
        RandmizeList(ref wordList);
       
       
        List<Salita> LearningPhaseWords = new List<Salita>();
       
   
            for (int x = 0; x < wordList.Count; x++)
            {
                if (!LearningPhaseWords.Contains(wordList[x]))
                {
                    LearningPhaseWords.Add(wordList[x]);
                    break;
                }
               
            }

        


        


       
            Salita salita = LearningPhaseWords[Random.Range(0, LearningPhaseWords.Count)];
            List<string> choices = new List<string>();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < wordList.Count; y++)
                {
                    if (!choices.Contains(wordList[y].name))
                    {
                        choices.Add(wordList[y].name);
                        break;
                    }

                }

            }





            choices.Clear();
        
    }
    void CombatStage()
    {

    
    
    }



}
