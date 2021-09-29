using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinner : MonoBehaviour
{

    Checker checker;


    RectTransform rectTransform;
    //  Vector3 mousepos;
    // Start is called before the first frame update

    void Awake()
    {
        checker = FindObjectOfType<Checker>();
        rectTransform = GetComponent<RectTransform>();
       



       

    }
    public void offsetStart()
    {
        rectTransform.Rotate(new Vector3(0, 0,0));
        int rand = Random.Range(1, 4);
        rectTransform.Rotate(new Vector3(0, 0, 120 * rand));
    }
    // Update is called once per frame
    void Update()
    {
        

    }
 

    public void RotateWheel(int x)
    {
        float z= (( (120 * x)));
       
        rectTransform.Rotate(new Vector3(0, 0,z));




    }

    public void CheckWheelrotation()
    {

        Debug.LogWarning((int)rectTransform.eulerAngles.z);
    checker.WheelChecker(((int)rectTransform.eulerAngles.z %360)==0);


    }
    


}
