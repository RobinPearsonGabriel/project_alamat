using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{

    public Vector2 startPosition;
    private Player myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = startPosition;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() != null)
        {
            myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            StartCoroutine("MoveFog");
        }
    }

    //void Update()
    //{
    //    int movement = myPlayer.levelsComplete.Length;
    //    for (int x = 0; x < movement; x++)
    //    {
    //        if (myPlayer.levelsComplete[x])
    //        {
    //            Debug.Log("Moving Fog");
    //            float newX = 3.0f + this.transform.position.x;
    //            this.transform.position = new Vector2(Mathf.Lerp(this.transform.position.x, newX, Time.deltaTime * 1), this.transform.position.y);
    //        }
    //    }
    //}

    IEnumerator MoveFog()
    {

        int movement = myPlayer.levelsComplete.Length;
        for (int x = 0; x < movement; x++)
        {
            if (myPlayer.levelsComplete[x])
            {
                Debug.Log("Moving Fog");
                float newX = 3.0f + this.transform.position.x;
                while (this.transform.position.x < newX)
                {
                    this.transform.position = new Vector2(this.transform.position.x + 0.01f, this.transform.position.y);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
