using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checker : MonoBehaviour
{
    Question_Script question;
    [SerializeField] Button spinnerEnterButton;
    [SerializeField] Button identificationEnterButton;
    [SerializeField] Button fourPicOneWordEnterButton;
    [SerializeField] Button scrollwheelEnterbutton;
    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<Question_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelScript.instance.currentPhase == roundPhase.Combat && LevelScript.instance.getCanAnswer())
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (LevelScript.instance.GetQuestionType())
                {
                    case QuestionType.Identification:

                        identificationEnterButton.onClick.Invoke();
                        break;
                    case QuestionType.Choices:



                        break;
                    case QuestionType.wheelGame:

                        spinnerEnterButton.onClick.Invoke();


                        break;

                    case QuestionType.FourSentenceOneWord:
                        fourPicOneWordEnterButton.onClick.Invoke();

                        break;

                    case QuestionType.ScrollWheel:
                        scrollwheelEnterbutton.onClick.Invoke();

                        break;
                    case QuestionType.ngNang:
                        break;
                    case QuestionType.rinDin:
                        break;
                    case QuestionType.Image:
                        break;
                    default:
                        break;


                }

            }

        }

    }

    // checker for Tmpprogui
    public void CheckWord(TextMeshProUGUI text)
    {
       

        bool s = question.GetSalita().salita.ToLower() == text.text.ToLower();
        Debug.Log(question.GetSalita().salita.ToLower() + text.text.ToLower());
        LevelScript.instance.result(s);


        
     

    }
    //checker for inputfields
    public void InputFieldChecker(TMP_InputField answer)
    {

        Debug.Log(answer.text);
        bool b = question.GetSalita().salita.ToLower() == answer.text.ToLower();
        Debug.Log(question.GetSalita().salita.ToLower() + answer.text.ToLower());
        LevelScript.instance.result(b);

        answer.text = "";

    }


    public void WheelChecker(bool e)
    {

        if (e)
        {
            Debug.LogWarning("Correct");
        }
        else
        {

            Debug.LogWarning("wrong");
        }
       
        LevelScript.instance.result(e);

    }

    public void scrollChecker(string text)
    {
        bool s = question.GetSalita().salita.ToLower() == text.ToLower();
        LevelScript.instance.result(s);
    }

    public void FourSentencesOneWord(string Answer)
    {
        LevelScript.instance.result(question.GetSalita().salita==Answer);
    }

}
