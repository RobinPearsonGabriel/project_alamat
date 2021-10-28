using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Skill_Base
{
    public override void ActivateSkill()
    {
        turnsSinceSpawned = 0;
        BurnDamage();
    }

    private void BurnDamage()
    {
        GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().TakeDamage(2);
    }

    public override void CheckSkillCondition()
    {
        if (turnsSinceSpawned < Duration)
        {
            BurnDamage();
        }
    }
}
