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
        Instantiate(migrainePrefab, spawnPosition);
    }

    protected override void DeactivateSkill()
    {
        Destroy(spawnedObject);
    }

}
