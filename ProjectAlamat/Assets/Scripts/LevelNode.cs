using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNode : MonoBehaviour
{
    public Player player;
    public int levelNumber;
    public Sprite completedImage;
    public Sprite incompleteImage;



    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>() != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player.levelsComplete[levelNumber])
            {
                this.GetComponent<Button>().GetComponent<Image>().sprite = completedImage;
            }
        }
    }
}
