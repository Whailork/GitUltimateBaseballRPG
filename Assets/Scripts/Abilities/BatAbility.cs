using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Abilities/BatAbility",fileName = "BatAbility_Default",order = 0)]
public class BatAbility : Ability
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void StartAbility(GameObject instigator)
    {
        base.StartAbility(instigator);
        instigator.GetComponent<Animator>().SetTrigger("Bat");
    }

    public override bool CanAddAbility(GameObject instigator)
    {
        return base.CanAddAbility(instigator);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
