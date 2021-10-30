using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsWithTheTrees : Skill_Base
{
    public override void ActivateSkill()
    {
        GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().TakeDamage(this.gameObject.GetComponent<Character_Base>().GetAtk()/2);
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog("The trees follow " + this.gameObject.GetComponent<EnemyScript>().getName() + "'s attack! Andres takes more damage!", false, " ", Dialog_Script.SpeakerSprite.Enemy);

    }
    // Update is called once per frame

}
