using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
[CreateAssetMenu(menuName = "Abilities/ThrowAbility",fileName = "ThrowAbility_Default",order = 0)]
public class ThrowAbility : Ability
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void StartAbility(GameObject instigator)
    {
 
        base.StartAbility(instigator);
        CharacterController charController = instigator.GetComponent<CharacterController>();
        Vector3 spawnPos = charController.ballSpawn.transform.position;
        

        GameObject ball = MonoBehaviour.Instantiate(charController.ballPrefab, spawnPos, Quaternion.identity);

        Vector3 target = charController.target;
        BallController controller = ball.GetComponent<BallController>();
        controller.SetDirection(target);
    }

}
