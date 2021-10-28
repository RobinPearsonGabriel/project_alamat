using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Character_Base : MonoBehaviour
{
    [SerializeField] Character_BaseStat characterBaseStat;
    // Start is called before the first frame update
  private  float atk;
    [Min(0)]
    public float hp;
    public float maxHp;
    float def;
    float lvl;
    characterType type;
    protected float countdown;
    string Type;
  
    [SerializeField] Image hpbar;

    [SerializeField]  SpriteRenderer spriteRenderer;

    public string getName()
    {
        return name;
    }
    public bool IsAlive()
    {

        return hp > 0;

    }
    public float GetAtk()
    {
        return atk;
    }
    characterType GetcharType()
    {

        return type;
    }
    public string GetCombatDialog()
    {

        return characterBaseStat.getCombatDialog();
    }
    protected virtual void Start()
    {
       
        setStats();
    }
    void setStats()
    {
        lvl = characterBaseStat.StartLvl;
        atk = characterBaseStat.baseAtk * (lvl * 0.5f);
        def = characterBaseStat.baseDef*(lvl*0.3f);
        maxHp = characterBaseStat.baseHp*(lvl*1.5f);
        hp = maxHp;
        spriteRenderer.sprite = characterBaseStat.NormalSprite;
        name = characterBaseStat.name;
        type = characterBaseStat.charType;
       

            countdown = characterBaseStat.countDown;
        

        hpbar.fillAmount = hp / maxHp;
    }

  
    public virtual bool Attack(GameObject Target)
    {
        if (Target.tag == "PlayerObject")
        {
            Target.GetComponent<PlayerScript>().TakeDamage(atk);
            Debug.Log(name + " attacked " + Target.GetComponent<PlayerScript>().name);
        }
        else
        {
            Target.GetComponent<EnemyScript>().TakeDamage(atk);
            Debug.Log(name + " attacked " + Target.GetComponent<EnemyScript>().name);

        }
        return false;
    }

    public void TakeDamage(float atkdamage)
    {
        float actualdamage = (atkdamage * (100 / (100 + def)));
        actualdamage = Mathf.Max(0, actualdamage);

        hp = hp- actualdamage;
        hpbar.fillAmount = hp / maxHp;
        hp = Mathf.Max(0.0f, hp);
        if (hp <= 0)
        {
            Die();
        
        }
        OnDamageRecieve(actualdamage);
    }
    public void OnDamageRecieve(float damage)
    {
        StartCoroutine(FlickeringEffect());
    }

    IEnumerator FlickeringEffect()
    {
        for (int i = 0; i < 20; i++)
        {
  spriteRenderer.color = Color.clear;
            
            yield return new WaitForSeconds(0.01f);
          spriteRenderer.color = Color.white;
        }
    }



    // Update is called once per frame
   protected virtual void Die()
    { 
    
    }


    void CharacterAnimation(List<Sprite>animation)
    { 
    
    
    }

}

public class Enemy_Class : Character_Base
{  public float experiencePoints;
    public Skill_Base PassiveSkill;
    float currcountDown;
   [SerializeField]  Image countdownBar;
    protected override void Start()
    {
        base.Start();
        currcountDown = 0;
        countdownBar.fillAmount = currcountDown / countdown;
    }
    void deductcountDown()
    {

        currcountDown++;
        countdownBar.fillAmount = currcountDown / countdown;

    }
  
    public float GetExperincePoint()
    {

        return experiencePoints;
    }

    public override bool Attack(GameObject Target)
    {
        if (currcountDown >= countdown)
        {
            currcountDown = 0;
            base.Attack(Target);
            Debug.LogWarning("atk");
            countdownBar.fillAmount = currcountDown / countdown;
            return true;
        }
        else
        {

            deductcountDown();
            if (PassiveSkill != null && PassiveSkill.GetDuration() <= 0)
            {
                PassiveSkill.CheckSkillCondition();
            }
            return false;
        }
       
    }

    protected override void Die()
    {
        LevelScript.instance.Victory();
    }

}




//Player
public class Player_Class : Character_Base
{
   
    protected float currExp;
    protected int maxLevelCap;
    public float expToLevel;
    protected void LevelUp()
    {
        

    }
    public void IncreaseLevelCap()
    {

    }
    public float GetExpToLevel()
    {
        return expToLevel;
    }

    public float getCurrentExp()
    {
        return currExp;
    }

    public void gainExp(float exp)
    {
        currExp += exp; 
        //save EXP
    
    }
    protected override void Die()
    {
        base.Die();
        LevelScript.instance.GameOver();
    }

}
