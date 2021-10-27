using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migraine : Skill_Base
{

    public GameObject migrainePrefab;
    public Transform spawnPosition;
    private GameObject spawnedObject;


    public override void ActivateSkill()
    {
        Instantiate(migrainePrefab, spawnPosition);
    }

    public override void DeactivateSkill()
    {
        Destroy(spawnedObject);
    }

}
