using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underground : Skill_Base
{
    private float previousHealth;

    // Start is called before the first frame update
    void Start()
    {
        previousHealth = this.gameObject.GetComponent<EnemyScript>().hp;
    }


    public override void CheckSkillCondition()
    {
        if (turnsSinceSpawned < Duration)
        {
            previousHealth = this.gameObject.GetComponent<EnemyScript>().hp;
        }
    }

    public override void ActivateSkill()
    {
        if(Random.Range(0,100) > 50)
        {
            this.gameObject.GetComponent<EnemyScript>().hp = previousHealth;  
        }
    }
}
