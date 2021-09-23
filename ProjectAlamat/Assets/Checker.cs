using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checker : MonoBehaviour
{
    Question_Script question;
    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<Question_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // checker for Tmpprogui
    public void CheckWord(TextMeshProUGUI text)
    {
       

        bool s = question.GetSalita().salita.ToLower() == text.text.ToLower();
        Debug.LogWarning(question.GetSalita().salita.ToLower() + text.text.ToLower());
        LevelScript.instance.result(s);


        
     

    }
    //checker for inputfields
    public void InputFieldChecker(TMP_InputField answer)
    {
        


            Debug.Log(answer.text);
        bool b = question.GetSalita().salita.ToLower() == answer.text.ToLower();
        Debug.LogWarning(question.GetSalita().salita.ToLower() + answer.text.ToLower());
        LevelScript.instance.result(b);



        answer.text = "";







    }


}
