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
   

    // Start is called before the first frame update
    void Start()
    {
        descriptionText = descriptionPanel.GetComponentInChildren<Text>();
        descriptionPanel.SetActive(false);

        descriptionText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSalita(List<Salita> words)
    {
       
        
            for (int i = 0; i < choicesText.Count; i++)
            {
              //  if (choicesText[i].text != null)
                    choicesText[i].text = words[i].salita;
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
