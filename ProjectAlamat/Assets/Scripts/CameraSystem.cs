using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    Vector3 touchStart;
    [Header("Camera Settings")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float cameraBorderThickness = 3f;
    [SerializeField] private Vector2 panLimit;
    [SerializeField] private Vector2 mapCenterPoint;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;
        // if (Input.GetMouseButtonDown(0))
        //{

        //    touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    cameraPos.x += direction.x;
        //}

        if (Input.mousePosition.x >= Screen.width - cameraBorderThickness)
            cameraPos.x += speed * Time.unscaledDeltaTime;

        if (Input.mousePosition.x <= cameraBorderThickness)
            cameraPos.x -= speed * Time.unscaledDeltaTime;



        cameraPos.x = Mathf.Clamp(cameraPos.x, mapCenterPoint.x - panLimit.x, mapCenterPoint.x + panLimit.x);

        this.transform.position = cameraPos;
    }
}
