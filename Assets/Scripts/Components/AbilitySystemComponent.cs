using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbilitySystemComponent : MonoBehaviour
{


    public Action<GameplayTag> abilityAdded;
    public Action<GameplayTag> abilityRemoved;
    public List<Ability> Abilities;
    
    public void AddAbility(Ability newAbility)
    {
        if (!Abilities.Contains(newAbility) && newAbility.CanAddAbility(gameObject))
        {
            Abilities.Add(newAbility);
            abilityAdded.Invoke(newAbility.AbilityTag);
        }
    }

    public void RemoveAbility(GameplayTag tagToRemove)
    {
        if (Abilities.FirstOrDefault(i => i.AbilityTag == tagToRemove) != null)
        {
            Abilities.Remove(Abilities.FirstOrDefault(i => i.AbilityTag == tagToRemove));
            abilityRemoved.Invoke(tagToRemove);
        }
        
    }

    public void RemoveAllAbilities()
    {
        Abilities.Clear();
    }

    public bool HasAbility(GameplayTag gTag)
    {
        if (Abilities.FirstOrDefault(i => i.AbilityTag) != null)
        {
            return true;
        }

        return false;
    }

    public void TriggerAbility(GameplayTag gTag)
    {
        if (HasAbility(gTag))
        {
            Abilities.FirstOrDefault(i => i.AbilityTag.tagName == gTag.tagName)?.StartAbility(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
