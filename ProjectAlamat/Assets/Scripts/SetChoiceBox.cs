using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetChoiceBox : MonoBehaviour
{
   [SerializeField] List<TextMeshProUGUI> choicesText;
    List<Salita> salitas;
    [SerializeField] GameObject descriptionPanel;
    Text descriptionText;
    [SerializeField] Button AnswerLockButton;
    TextMeshProUGUI AnswerSelected;
    Checker checker;
    // Start is called before the first frame update
    void Start()
    {
        checker = FindObjectOfType<Checker>();
        descriptionText = descriptionPanel.GetComponentInChildren<Text>();
        descriptionPanel.SetActive(false);

        descriptionText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetAnswer(TextMeshProUGUI text)
    {


        AnswerSelected = text;


        AnswerLockButton.interactable = true;

        foreach (TextMeshProUGUI textMesh in choicesText)
        {
            if (textMesh != AnswerSelected)
            {
                textMesh.color = Color.black;
            }
            else
            {
                textMesh.color = Color.gray;
            }
        }
    }
    public void AnswerLock()
    {
        checker.CheckWord(AnswerSelected);
    }

    public void setSalita(List<Salita> words)
    {
        AnswerSelected = null;
        AnswerLockButton.interactable = false;
            for (int i = 0; i < choicesText.Count; i++)
            {
              //  if (choicesText[i].text != null)
                    choicesText[i].text = words[i].salita;
            choicesText[i].color = Color.black;
            }
        salitas = words;

    
    }

    public void DescriptionPanelActive(int x)
    {
        descriptionPanel.SetActive(true);

        descriptionText.text = "Description "+ salitas[x].description;

    }

    public void DescriptionClear()
    {

        descriptionPanel.SetActive(false);

        descriptionText.text ="";
    }

}
