using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum characterType {player,enemy };
[CreateAssetMenu]
public class Character_BaseStat : ScriptableObject
{
 public characterType charType;
    
    

   
    public new string name;
    public Sprite NormalSprite;
    public List<Sprite> atkAnimation;
    public List<Sprite> DeathAnimation;
    public List<Sprite> damagedAnimation;
    public List<string> CombatDialogs;
    
    public int baseHp;
   public int baseAtk;
   public int baseDef;
    public int StartLvl;
    public int countDown;
    // Start is called before the first frame update
    public string getCombatDialog()
    {
        int rand = Random.Range(0, CombatDialogs.Count);
        string x = "";

        if (CombatDialogs[rand] != null)
        {
            x = CombatDialogs[rand];
        }
        return x;

            
    }
    public string getName()
    {
        return name;
    }
}
