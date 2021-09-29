using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int level;
    public bool[] levelsComplete;

    public PlayerData(Player player)
    {
        level = player.level;

        for (int i = 0; i <= levelsComplete.Length - 1; i++)
        {
            levelsComplete[i] = player.levelsComplete[i];
        }
    }
}
