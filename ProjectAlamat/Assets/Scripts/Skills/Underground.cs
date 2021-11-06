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
            if (this.gameObject.GetComponent<EnemyScript>().hp != previousHealth)
            {
                this.gameObject.GetComponent<EnemyScript>().hp = previousHealth;
                GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog(this.gameObject.GetComponent<EnemyScript>().getName() + " dodged the attack", false, " ", Dialog_Script.SpeakerSprite.Enemy);
            }
          }
    }
}
