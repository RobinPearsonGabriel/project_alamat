using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    [SerializeField] Character_BaseStat characterType;
    // Start is called before the first frame update
  private  float atk;
    [Min(0)]
    public float hp;
    float maxHp;
    float def;
  private float lvl;
    public string nname;
   [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        setStats();
    }
    void setStats()
    {
        lvl = characterType.StartLvl;
        atk = characterType.baseAtk * (lvl * 0.5f);
        def = characterType.baseDef*(lvl*0.3f);
        maxHp = characterType.baseHp*(lvl*1.5f);
        hp = maxHp;
        spriteRenderer.sprite = characterType.sprite;
        name = characterType.name;

    }

     void Update_Stats()
    {
        atk += lvl * 2;
        maxHp += lvl * 10;
        
    }

    public virtual void Attack(GameObject Target)
    {
        if (Target.tag == "Player")
        {
            Target.GetComponent<PlayerScript>().TakeDamage(atk);
            Debug.Log(name + " attacked " + Target.GetComponent<PlayerScript>().name);
        }
        else
        {
            Target.GetComponent<EnemyScript>().TakeDamage(atk);
            Debug.Log(name + " attacked " + Target.GetComponent<EnemyScript>().name);

        }
    }

    public void TakeDamage(float atkdamage)
    {
        float actualdamage = (atkdamage * (100 / (100 + def)));
        actualdamage = Mathf.Max(0, actualdamage);

        hp = hp- actualdamage;
        OnDamageRecieve(actualdamage);
    }
    public void OnDamageRecieve(float damage)
    {
        
    }
    // Update is called once per frame
    
}

public class Enemy_Class : Character_Base
{

    protected int experiencePoints;
    public int GetExperincePoint()
    {

        return experiencePoints;
    }

}
public class Player_Class : Character_Base
{
   protected int exp;
   protected int maxLevelCap;
    
    protected   void LevelUp()
    {


    }
    public void IncreaseLevelCap()
    { 
    
    }
}
