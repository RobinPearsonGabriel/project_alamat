using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Migraine : Skill_Base
{
    public Canvas canvas;
    public GameObject migrainePrefab;
    public Transform spawnPosition;
    private GameObject spawnedObject;


    public override void ActivateSkill()
    {
        turnsSinceSpawned = 0;
        spawnedObject = Instantiate(migrainePrefab, spawnPosition);
        spawnedObject.transform.parent = canvas.transform;
        GameObject.FindWithTag("LevelManager").GetComponent<Dialog_Script>().AddDialog(this.gameObject.GetComponent<EnemyScript>().getName() + " is attacking Andres's mind " + "\n Andres isn't able to focus!", false, " ", Dialog_Script.SpeakerSprite.Enemy,DialogList.Speaker.Enemy,DialogList.Pos.farleft);

    }

    protected override void DeactivateSkill()
    {
        Destroy(spawnedObject);
    }



}
