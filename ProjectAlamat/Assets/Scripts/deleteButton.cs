using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteButton : MonoBehaviour
{
    public void onClick(int SaveFileNumber)
    {
        if (PlayerPrefs.HasKey("saveFile" + SaveFileNumber.ToString()))
        {
            Debug.Log("Key Exists");
            PlayerPrefs.DeleteKey("saveFile" + SaveFileNumber.ToString());
            Debug.Log("Deleting Key");
        }
    }
}
