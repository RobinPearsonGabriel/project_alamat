using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{

    public Vector2 startPosition;
    private Player myPlayer;
    private float newX;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() != null)
        {
            myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    void OnEnable()
    {
        Debug.Log("Fog Enabled");
        FogStart();
    }

    void FogStart()
    {
        newX = 0;

        foreach (bool completeLevel in myPlayer.levelsComplete)
        {
            if (completeLevel)
            {
                newX += 4.5f;
            }
        }
        this.transform.position = new Vector2 (startPosition.x + newX,startPosition.y);
        newX = 4.5f + this.transform.position.x;
        Debug.Log("Setting Fog:" + this.transform.position.x);
        InvokeRepeating("MoveFog", 1, 0.01f);
        //StartCoroutine("MoveFog");
    }


    public void MoveFog()
    {
        Debug.Log("MovingFog");
        if (this.transform.position.x < newX)
        {
            this.transform.position = new Vector2(this.transform.position.x + 0.01f, this.transform.position.y);
        }
        else
        {
            Debug.Log("FinishedMoving");
            CancelInvoke();
        }
    }



    //IEnumerator MoveFog()
    //{
    //    Debug.Log("Moving Fog");
    //    float newX = 5.0f + this.transform.position.x;
    //    Debug.Log(newX);
    //    while (this.transform.position.x < newX)
    //    {
            
    //        this.transform.position = new Vector2(this.transform.position.x + 0.01f, this.transform.position.y);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    Debug.Log(this.transform.position.x);
    //    Debug.Log(newX);
    //}
}

