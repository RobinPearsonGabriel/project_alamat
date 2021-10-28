using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Skill_Base
{
    public override void ActivateSkill()
    {
        GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().TakeDamage(this.gameObject.GetComponent<Character_Base>().GetAtk()/2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSkill();
        }
    }
}
