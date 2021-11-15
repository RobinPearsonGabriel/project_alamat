using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardScript : MonoBehaviour
{
    public TextMeshProUGUI PlayerInput;
    [SerializeField] GameObject showKeyboardButton;
    [SerializeField] GameObject Keyboard;
    List<char> temp = new List<char>();
    int numberOfLetters=0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SetUnderline()
    {
        numberOfLetters = 0;
        PlayerInput.text = "";
        char[] textArr = LevelScript.instance.gameObject.GetComponent<Question_Script>().GetSalita().salita.ToCharArray();
        if (temp.Count <= 0)
        {
            for (int x = 0; x < textArr.Length; x++)
            {
                temp.Add('_');
            }
        }
        string text = new string(temp.ToArray());
        PlayerInput.text = text;
        temp.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TypeKey(string word)
    {
        if (numberOfLetters < PlayerInput.text.Length)
        {
            char[] textArr = PlayerInput.text.ToCharArray();
            textArr[numberOfLetters] = word[0];
            for (int x = 0; x < textArr.Length; x++)
            {
                temp.Add(textArr[x]);
            }
            string text = new string(temp.ToArray());
            PlayerInput.text = text;
            numberOfLetters++;
            temp.Clear();
        }

    }

    public void Clear()
    {
        numberOfLetters = 0;
        PlayerInput.text = "";
        char[] textArr = LevelScript.instance.gameObject.GetComponent<Question_Script>().GetSalita().salita.ToCharArray();
        if (temp.Count <= 0)
        {
            for (int x = 0; x < textArr.Length; x++)
            {
                temp.Add('_');
            }
        }
        string text = new string(temp.ToArray());
        PlayerInput.text = text;
        temp.Clear();
    }
    public void ActivateKeyBoard()
    {
        showKeyboardButton.SetActive(Keyboard.activeSelf);
        Keyboard.SetActive(!Keyboard.activeSelf);
          

    
    }
}
