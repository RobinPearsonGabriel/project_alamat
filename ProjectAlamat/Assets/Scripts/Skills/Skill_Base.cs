using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Base : MonoBehaviour
{
    public int cooldown;
    protected int currentTurn;


    // Start is called before the first frame update
    void Start()
    {
        currentTurn = 0;
    }

    public virtual void ActivateSkill()
    {

    }
    public virtual void DeactivateSkill() 
    {

    }


}
