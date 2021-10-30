using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : Skill_Base
{
    public override void ActivateSkill()
    {
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog(this.gameObject.GetComponent<EnemyScript>().getName() + " caused an Earthquake! " + "\n Andres has to keep himself from falling!", false, " ", Dialog_Script.SpeakerSprite.Enemy);
        this.gameObject.GetComponent<EnemyScript>().Attack(null);
    }
    // Update is called once per frame

}
