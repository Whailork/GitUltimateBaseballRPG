using System.Collections;
using System.Collections.Generic;
using Singletons;
using UnityEngine;

public class CharacterArm : MonoBehaviour
{
    public CharacterController linkedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBall()
    {
        linkedCharacter.GetComponent<AbilitySystemComponent>().TriggerAbility(GameplayTags.GetGameplayTagsInstance().GameplayTagList["Throw"]);
    }
}
