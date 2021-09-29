using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    [Header("Camera Settings")]
    [SerializeField] private float speed = 20f;
    [SerializeField] private float cameraBorderThickness = 10f;
    [SerializeField] private Vector2 panLimit;
    [SerializeField] private Vector2 mapCenterPoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = transform.position;

        if (Input.mousePosition.x >= Screen.width - cameraBorderThickness)
            cameraPos.x += speed * Time.unscaledDeltaTime;

        if (Input.mousePosition.x <= cameraBorderThickness)
            cameraPos.x -= speed * Time.unscaledDeltaTime;

        if (Input.GetKeyDown(KeyCode.D))
            cameraPos.x += speed * Time.unscaledDeltaTime;

        if (Input.GetKeyDown(KeyCode.A))
            cameraPos.x -= speed * Time.unscaledDeltaTime;


            cameraPos.x = Mathf.Clamp(cameraPos.x, mapCenterPoint.x - panLimit.x, mapCenterPoint.x + panLimit.x);

        this.transform.position = cameraPos;
    }
}
