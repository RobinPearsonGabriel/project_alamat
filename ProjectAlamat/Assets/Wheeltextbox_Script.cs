using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheeltextbox_Script : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }

    // 2nd approch
    //void LateUpdate()
    //{
    //    transform.rotation = Quaternion.identity; ;
    //}
}
