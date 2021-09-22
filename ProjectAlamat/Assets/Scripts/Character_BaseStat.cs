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
    public int baseHp;
   public int baseAtk;
   public int baseDef;
    public int StartLvl;
    public int countDown;
    // Start is called before the first frame update
   
}
