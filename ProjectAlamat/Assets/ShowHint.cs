using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowHint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HintText;
    Question_Script question_Script;
    [SerializeField] Button identificationHintButton;
    [SerializeField] Button ChoicesHintButton;
    [SerializeField] List<GameObject> Choices;
    Color color;
   // char[] textArr;
    List<char> temp= new List<char>();
    int numOfErasedText = 0;
    // Start is called before the first frame update
    void Start()
    {
        question_Script = FindObjectOfType<Question_Script>();


        color = Choices[0].GetComponent<Image>().color;


    }

    public void SetHintText()
    {

        if (question_Script == null)
        {

            Debug.LogWarning("sfad");
        }

        char[] textArr = question_Script.GetSalita().salita.ToCharArray();
        if (temp.Count <= 0)
        {
            for (int x = 0; x < textArr.Length; x++)
            {
                temp.Add('_');
            }
        }
       
        for (int i = 0; i < 1;)
        {


            int rand = Random.Range(0, textArr.Length);
            if (temp[rand] == '_')
            {
                temp[rand] = textArr[rand];
                numOfErasedText++;
                i++;

            }


        }    Debug.LogWarning(textArr.Length);

        string text = new string(temp.ToArray());

        HintText.text = text;
        HintText.enabled = true;
    
       identificationHintButton.interactable = textArr.Length-1 > numOfErasedText;
    }



    public void resetHint()
    {
        temp.Clear();
        numOfErasedText = 0;
        HintText.text = "";
        HintText.enabled = true;
        identificationHintButton.interactable = true;

        foreach (GameObject obj in Choices)
        {
            obj.GetComponent<Image>().color=color;

        }
        ChoicesHintButton.interactable = true;
    }
    public void HintChoices()
    {
        ChoicesHintButton.interactable = false;
        foreach (GameObject obj in Choices)
        {
            TextMeshProUGUI[] texts = obj.GetComponentsInChildren<TextMeshProUGUI>();
            if (texts[1].text== question_Script.GetSalita().salita)
            {
                obj.GetComponent<Image>().color= Color.red;
            
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        




    }
}
