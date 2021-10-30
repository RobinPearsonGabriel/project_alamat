using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scald : Skill_Base
{
    public override void ActivateSkill()
    {
        GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().AtkPercentIncrease(-1.0f, null);
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog(this.gameObject.GetComponent<EnemyScript>().getName() + " fires scalding water " + "\n The hot water breaks Andres's concentration!", false, " ", Dialog_Script.SpeakerSprite.Enemy);
    }
    // Update is called once per frame
}
