using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteButton : MonoBehaviour
{
    public void onClick()
    {
        PlayerPrefs.DeleteAll();
    }
}
