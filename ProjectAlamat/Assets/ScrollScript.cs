using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ScrollScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool onPanel;
    bool hasClicked;
    Vector3 prevPos;
    Vector3 CurrentPos;
    [SerializeField]List <GameObject> Texts;
    [SerializeField] GameObject panel;
    float maxDistance = 50;
    [SerializeField] Text incompleteTextbox;
    int maxFontsize=30;
    int minfontsize=8;
    Checker checkerScript;
    // Start is called before the first frame update
    void Start()
    {
        checkerScript = FindObjectOfType<Checker>();
        maxDistance += this.transform.position.y;
        onPanel = false;
        hasClicked = false;
    }
   public void setTexts(string questions, List<string>texts)
    {
        Debug.LogError(questions) ;
        for (int i = 0; i < 3; i++)
        {
            Texts[i].GetComponent<Text>().text = texts[i];
        }
        incompleteTextbox.text = questions;
    }

public    void CheckText()
    {
        GameObject obj = Texts[0];
        foreach (GameObject item in Texts)
        {
          
            if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(obj.transform.position, transform.position))
            {
                obj = item;
            }

        }
        checkerScript.scrollChecker(obj.GetComponent<Text>().text);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (hasClicked)
            {
                if (onPanel)
                {


                    CurrentPos = Input.mousePosition;
                    float movementDirection = 1;
                    if (CurrentPos.y > prevPos.y)
                    {
                        movementDirection = 1;
                    }
                    else if (CurrentPos.y < prevPos.y)
                    {
                        movementDirection = -1;
                    }
                    else
                    {
                        movementDirection = 0;
                    }

                    float dis = Vector3.Distance(CurrentPos, prevPos);
                    //float A = ((CurrentPos.x * CurrentPos.x) - (prevPos.x * prevPos.x)) + ((CurrentPos.y * CurrentPos.y) - (prevPos.y * prevPos.y));
                    //A = Mathf.Sqrt(A);

                    // float B = Vector3.Distance(CurrentPos, transform.position);
                    // float C = Vector3.Distance(prevPos, transform.position);

                    // Debug.LogError(movementDirection);

                    foreach (GameObject item in Texts)
                    {

                        //item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y + (movementDirection * dis), item.transform.position.z);


                     //   Debug.LogWarning(Vector2.Distance(item.transform.position, transform.position));


                    }
                    panel.transform.position = new Vector3(panel.transform.position.x, panel.transform.position.y + (movementDirection * dis), panel.transform.position.z);
                    //  a.transform.position = new Vector3(a.transform.position.x, a.transform.position.y + (movementDirection * dis), a.transform.position.z);
                    //  b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y + (movementDirection * dis), b.transform.position.z);
                    //  c.transform.position = new Vector3(c.transform.position.x, c.transform.position.y + (movementDirection * dis), c.transform.position.z);

                    //  Debug.LogError(Vector3.Distance(a.transform.position, transform.position));







                    Debug.Log(movementDirection);





                    //  transform.position = Input.mousePosition;
                    //transform.rotation = new Vector4(new);
                    //  transform.position =
                    //  Input.mousePosition;

                    // transform.localRotation = Quaternion.Euler(0,0,z);
                    //rectTransform.Rotate(new Vector3(0, 0, z));
                    prevPos = CurrentPos;
                }
            }
            else
            {
                prevPos = Input.mousePosition;
                CurrentPos = prevPos;
                hasClicked = true;


            }
        }
        if (!hasClicked)
        {


            Vector3 nearest= Texts[0].transform.position;
            foreach (GameObject item in Texts)
            {
                if (Vector3.Distance(item.transform.position, transform.position) < Vector3.Distance(nearest, transform.position))
                {
                    nearest = item.transform.position;
                }
             

               

            }
         

            float a = transform.position.y- nearest.y ;
            if (Vector3.Distance(nearest, transform.position)>0)
            {
               // transform.position = new Vector3(transform.position.x, a, transform.position.z);
                panel.transform.position = Vector3.Lerp(panel.transform.position, new Vector3(panel.transform.position.x,panel.transform.position.y + a, panel.transform.position.z), Vector3.Distance(nearest, transform.position)/2*Time.deltaTime);
            }
        }
        foreach (GameObject item in Texts)
        {
            float x;
        
            x = (1.0f - (Vector2.Distance(item.transform.position, transform.position) / (maxDistance))) * maxFontsize;

            //Debug.LogWarning(Vector2.Distance(item.transform.position, transform.position));
            item.GetComponent<Text>().fontSize = Mathf.Clamp((int)x, minfontsize, maxFontsize);

        }
        if (Input.GetMouseButtonUp(0))
        {

            hasClicked = false;
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        onPanel=true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPanel = false;
    }

}
