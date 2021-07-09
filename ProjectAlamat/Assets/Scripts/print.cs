using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class print : MonoBehaviour
{
    public Salita salita;
   
    public TextMeshProUGUI textMesh;
    private void Start()
    {
     

        textMesh.text= salita.tagalogSentenceTraining + "\n" + salita.englishSentenceTraining;
    }

    private void Update()
    {
        
    }
}
