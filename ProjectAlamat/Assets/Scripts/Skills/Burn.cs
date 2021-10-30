using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Skill_Base
{
    void Start()
    {
        turnsSinceSpawned = Duration;
    }

    public override void ActivateSkill()
    {
        turnsSinceSpawned = 0;
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog(this.gameObject.GetComponent<EnemyScript>().getName() + " burns Andres " + "\n That burn is gonna hurt!", false, " ", Dialog_Script.SpeakerSprite.Enemy);
    }

    private void BurnDamage()
    {
        GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().TakeDamage(2);
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog("Andres takes damage from his burn!", false, " ", Dialog_Script.SpeakerSprite.Enemy);
    }

    public override void CheckSkillCondition()
    {
        if (turnsSinceSpawned < Duration)
        {
            BurnDamage();
            turnsSinceSpawned++;
        }
    }
}
