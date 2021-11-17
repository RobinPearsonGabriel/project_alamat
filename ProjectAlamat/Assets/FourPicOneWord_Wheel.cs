using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FourPicOneWord_Wheel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

  int  currentIndex;
    List<string> choices;
        Checker checker;
        bool isRotating;
        Vector2 Rot;
        Vector3 prevPos;
        Vector3 CurrentPos;
        bool hasChanged;
        float degree=0;
        [SerializeField] Text choiceBox;
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
        choices = new List<string>();
            checker = FindObjectOfType<Checker>();
            hasSnapped = false;
            rectTransform = GetComponent<RectTransform>();
            // checker = FindObjectOfType<Checker>();

            hasChanged = false;

        currentIndex = Random.Range(0, choices.Count-1);

        }
        public void offsetStart()
        {
            rectTransform.Rotate(new Vector3(0, 0, 0));
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
                        float movementDirection = 1;

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

                                if (CurrentPos.y > prevPos.y || CurrentPos.x < prevPos.x)
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


                        Debug.Log(currentIndex);




                        // Debug.Log(z);
                        //  transform.position = Input.mousePosition;
                        //transform.rotation = new Vector4(new);
                        //  transform.position =
                        //  Input.mousePosition;
                        transform.eulerAngles += Vector3.forward * -z * movementDirection;
                    degree += -z * movementDirection;


                        currentIndex = (((int)degree / 360) %choices.Count);
                    if (currentIndex < 0)
                    {
                        currentIndex += choices.Count;
                    }
                    // currentIndex = Mathf.Clamp(currentIndex, 0, choices.Count);
                    // currentIndex = -1 % choices.Count;   
                    
                    choiceBox.color = new Vector4(choiceBox.color.r, choiceBox.color.g, choiceBox.color.b, Mathf.Clamp(1-((rectTransform.eulerAngles.z % 360)/360), 0.1f, 1.0f));


                        // transform.localRotation = Quaternion.Euler(0,0,z);
                        //rectTransform.Rotate(new Vector3(0, 0, z));
                    prevPos = CurrentPos;
                        diff = Mathf.Abs((zPrev % 360) - rectTransform.eulerAngles.z);
                        Debug.LogWarning(zPrev + "  " + rectTransform.eulerAngles.z);

                    }
                    else
                    {
                        prevPos = Input.mousePosition;
                        CurrentPos = prevPos;
                        hasChanged = true;
                 



                    }
                }

            if (choices != null&& currentIndex < choices.Count)
            {
                choiceBox.text = choices[currentIndex];
            }
                if (Input.GetMouseButtonUp(0))
                {
                    // Debug.Log(rectTransform.eulerAngles.z % 360);
                    hasChanged = false;



                }

            

            }
        }
  public  void setchoices(List<string> choice)
    {
        choices = choice;
    
    }

    public void checkAnswer()
    {
        checker.FourSentencesOneWord(choices[currentIndex]);
    
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



    
}
