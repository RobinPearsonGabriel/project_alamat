using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public float xOffset;
    public GameObject cursor;
    GraphicRaycaster raycaster;
    public string tagName;
    public EventSystem eventSystem;

    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }
    
    public void ChangeCursorLocation(GameObject hoveredGameObject)
    {
        if (cursor.transform.parent != hoveredGameObject.transform)
        {
            cursor.transform.SetParent(hoveredGameObject.transform);
            cursor.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(xOffset, 0);
            
        }
    }

    void Update()
    {
        PointerEventData ped  = new PointerEventData(eventSystem);
        ped.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(ped, results);

        foreach (RaycastResult result in results)
        {
            if(result.gameObject.tag == tagName)
            {
                ChangeCursorLocation(result.gameObject);
            }
            Debug.Log("Hit " + result.gameObject.name);

        }
    }
}
