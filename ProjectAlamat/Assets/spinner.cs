using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class spinner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

  Checker checker;
    bool isRotating;
    Vector2 Rot;
    Vector3 prevPos;
    Vector3 CurrentPos;
    bool hasChanged;
    float zrot = 0;

    [SerializeField] bool isFourpicOneWord;
   // Vector4 Rot  Quaternion;
    RectTransform rectTransform;
    float diff;
    float zPrev;
    bool hasSnapped;
    //  Vector3 mousepos;
    // Start is called before the first frame update

    void Awake()
    {
        checker = FindObjectOfType<Checker>();
        hasSnapped = false;
        rectTransform = GetComponent<RectTransform>();
 // checker = FindObjectOfType<Checker>();

        hasChanged = false;

       

    }
    public void offsetStart()
    {
        rectTransform.Rotate(new Vector3(0, 0,0));
        int rand = Random.Range(100, 300);
        zPrev = rectTransform.eulerAngles.z;
        rectTransform.Rotate(new Vector3(0, 0, rand));
    }
    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (isRotating)
        {
            if (Input.GetMouseButton(0))
            {
                if (hasChanged)
                {

                    
                    CurrentPos = Input.mousePosition;
                    float movementDirection =1;
                   
                    float A = Vector3.Distance(CurrentPos, prevPos);
                    //float A = ((CurrentPos.x * CurrentPos.x) - (prevPos.x * prevPos.x)) + ((CurrentPos.y * CurrentPos.y) - (prevPos.y * prevPos.y));
                    //A = Mathf.Sqrt(A);
                    
                    float B = Vector3.Distance(CurrentPos, transform.position);
                    float C = Vector3.Distance(prevPos, transform.position);
                    //find angle A
                    float z = (B * B) + (C * C) - (A * A);
                    z = z / (2 * B * C);
                    z = Mathf.Acos(z);
                    z = (z * 180) / Mathf.PI;



                    if (CurrentPos.x > transform.position.x)
                    {
                        //Q1
                        if (CurrentPos.y > transform.position.y)
                        {
                            
                            if (CurrentPos.y > prevPos.y|| CurrentPos.x < prevPos.x)
                            {
                                movementDirection = -1;
                            }
                        }
                        //Q4
                       else if (CurrentPos.y < transform.position.y)
                        {
                            if (CurrentPos.y > prevPos.y || CurrentPos.x > prevPos.x)
                            {
                                movementDirection = -1;
                            }
                        }
                    }
                    else
                    {
                        //Q2
                        if (CurrentPos.y > transform.position.y)
                        {
                            if (CurrentPos.y < prevPos.y || CurrentPos.x < prevPos.x)
                            {
                                movementDirection = -1;
                            }
                        }

                        //Q4
                        else if (CurrentPos.y < transform.position.y)
                        {
                            if (CurrentPos.y < prevPos.y || CurrentPos.x > prevPos.x)
                            {
                                movementDirection = -1;
                            }
                        }


                    }
                  

                    Debug.Log(movementDirection);




                   // Debug.Log(z);
                    //  transform.position = Input.mousePosition;
                    //transform.rotation = new Vector4(new);
                    //  transform.position =
                    //  Input.mousePosition;
                    transform.eulerAngles += Vector3.forward * -z*movementDirection;
                    // transform.localRotation = Quaternion.Euler(0,0,z);
                    //rectTransform.Rotate(new Vector3(0, 0, z));
                    prevPos = CurrentPos;
                    diff = Mathf.Abs((zPrev%360) -rectTransform.eulerAngles.z);
                    Debug.LogWarning(zPrev + "  " + rectTransform.eulerAngles.z);

                }
                else
                { 
                    prevPos = Input.mousePosition;
                    CurrentPos = prevPos;
                    hasChanged = true;
                    hasSnapped = false;
                 


                }
            }
            if (Input.GetMouseButtonUp(0))
            {
               // Debug.Log(rectTransform.eulerAngles.z % 360);
                hasChanged = false;

            

            }

            if (!hasChanged)
            {if(!hasSnapped)
                { 
                if (diff >= 20)
                {
                    zrot = zPrev + 180;
                }
                else
                {
                    zrot = zPrev;
                }
                if (isFourpicOneWord)
                {




                    Quaternion targetRotations = Quaternion.Euler(new Vector3(0f, 0f, zrot));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotations, 10.0f);



                }
                zPrev = zrot;
                hasSnapped = true;
            }
            }

        }
        




      


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isRotating = true;


        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isRotating = false;
        hasChanged = false;

      
    }

   



    
    public void CheckWheelrotation()
    {

        
        Debug.LogWarning(rectTransform.eulerAngles.z % 360 + " " );
       checker.WheelChecker((rectTransform.eulerAngles.z % 360 < 30.0f|| rectTransform.eulerAngles.z % 360 > 330));

       






    }



}
