using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : Skill_Base
{


    public override void ActivateSkill()
    {
        GameObject.FindWithTag("LevelManager").GetComponent<LevelScript>().result(false);
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
