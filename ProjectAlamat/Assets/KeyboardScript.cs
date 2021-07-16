using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardScript : MonoBehaviour
{
    public TMP_InputField PlayerInput;
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
}
