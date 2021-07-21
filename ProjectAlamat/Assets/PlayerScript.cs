using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Player_Class
{

   
    // Start is called before the first frame update
 protected override  void Start()
    {
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

}
