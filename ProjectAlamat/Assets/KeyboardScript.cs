using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardScript : MonoBehaviour
{
    public TMP_InputField PlayerInput;
    [SerializeField] GameObject showKeyboardButton;
    [SerializeField] GameObject Keyboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TypeKey(string word)
    {
        string text = PlayerInput.text + word;
        PlayerInput.text = text;

    }

    public void Clear()
    {
        string text = "";
        PlayerInput.text = text;

    }
    public void ActivateKeyBoard()
    {
        showKeyboardButton.SetActive(Keyboard.activeSelf);
        Keyboard.SetActive(!Keyboard.activeSelf);
          

    
    }
}
