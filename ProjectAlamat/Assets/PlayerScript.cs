﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : Player_Class
{

    float atkPercent;
    [SerializeField] Image atkPercentfill;

    // Start is called before the first frame update
    protected override  void Start()
    {
        atkPercent = 0;
        base.Start();
        expToLevel = 100;
        currExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Die()
    {
        base.Die();
    }

   public void AtkPercentIncrease(float weight,GameObject enemy)
    {
        atkPercent += weight;
        atkPercentfill.fillAmount = atkPercent / 3.0f;

        if (atkPercent >= 3)
        {
            atkPercent = 0;
            atkPercentfill.fillAmount = 0;
            Attack(enemy);
        
        }


    }

    

}