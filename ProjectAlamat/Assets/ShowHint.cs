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

            Debug.LogError("sfad");
        }
        identificationHintButton.interactable = false;
        char[] textArr = question_Script.GetSalita().salita.ToCharArray();
        int numOfErasedText = textArr.Length / 4;

        for (int i = 0; i < numOfErasedText;)
        {


            int rand = Random.Range(0, textArr.Length);
            if (textArr[rand] != '_')
            {
                textArr[rand] = '_';
                i++;

            }


        }

        string text = new string(textArr);

        HintText.text = text;
        HintText.enabled = true;

    }



    public void resetHint()
    {
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
