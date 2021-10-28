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
        spawnedObject = Instantiate(migrainePrefab, spawnPosition);
        spawnedObject.transform.parent = canvas.transform;

    }

    protected override void DeactivateSkill()
    {
        Destroy(spawnedObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSkill();
        }
    }

}
