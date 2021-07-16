using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class print : MonoBehaviour
{
    public Salita salita;
    public TMP_InputField InputA;
    public TextMeshProUGUI textMesh;
    private void Start()
    {
     

        textMesh.text= salita.tagalogSentenceTraining + "\n" + salita.englishSentenceTraining;
    }

    private void Update()
    {
        
    }


    public void Printa(string word)
    {
        string text = InputA.text + word;
        InputA.text=text;

    }
}
