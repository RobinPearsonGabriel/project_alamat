using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("DeleteObject", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteObject()
    {
        this.gameObject.SetActive(false);
    }
}
