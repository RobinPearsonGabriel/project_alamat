using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scald : Skill_Base
{
    public override void ActivateSkill()
    {

        if (GameObject.FindWithTag("PlayerObject").GetComponent<PlayerScript>().AtkPercentIncrease(-1.0f, null))
        {
            Debug.Log("Player Scalded");
        }

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
