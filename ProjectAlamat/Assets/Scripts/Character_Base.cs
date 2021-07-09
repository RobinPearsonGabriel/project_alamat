using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    // Start is called before the first frame update
  private  int atk;
    [Min(0)]
    public int hp;
    int maxHp;
    private int def;
  private  int lvl;


     void Update_Stats()
    {
        atk += lvl * 2;
        maxHp += lvl * 10;
        
    }

    protected virtual void Attack(GameObject Target)
    { 
    
    }

    public void TakeDamage(int atkdamage)
    {
        int actualdamage = (atkdamage * (100 / (100 + def)));
        actualdamage = Mathf.Max(0, actualdamage);

        hp = hp- actualdamage;
        OnDamageRecieve(actualdamage);
    }
    public void OnDamageRecieve(int damage)
    {
        
    }
    // Update is called once per frame
    
}

public class Enemy_Class : Character_Base
{ 
    


}
public class Player_Class : Character_Base
{
    int exp;
    int maxLevelCap;
    
    protected   void LevelUp()
    {


    }
    public void IncreaseLevelCap()
    { 
    
    }
}
