using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum characterType {player,enemy };
[CreateAssetMenu]
public class Character_BaseStat : ScriptableObject
{
 public characterType charType;
    
    

   
    public new string name;
    public Sprite sprite;
   public int baseHp;
   public int baseAtk;
   public int baseDef;
    // Start is called before the first frame update
   
}
