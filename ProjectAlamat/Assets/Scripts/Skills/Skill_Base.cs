using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Base : MonoBehaviour
{
    public int cooldown;
    public int turnsSinceSpawned;
    public int Duration;


    // Start is called before the first frame update
    void Start()
    {
        turnsSinceSpawned = 0;
    }

    public virtual void ActivateSkill()
    {

    }
    protected virtual void DeactivateSkill() 
    {

    }

    public virtual void CheckSkillCondition()
    {
        if (turnsSinceSpawned >= Duration)
        {
            DeactivateSkill();
        }
    }

    public void AddTurn()
    {
        turnsSinceSpawned++;
        CheckSkillCondition();
    }

}
