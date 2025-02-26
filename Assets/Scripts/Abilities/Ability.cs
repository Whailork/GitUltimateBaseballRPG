using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    public GameplayTag AbilityTag;

    public List<GameplayTag> abilityBlockerTags;
    bool bCanAdd;
    bool bCanStart;
    // Fonctions

	
    // Demarre l’ability

    public virtual void StartAbility(GameObject instigator)
    {
	    OnAbilityStarted(instigator);
    }
    // Arrete l’ability
    public virtual void StopAbility(GameObject instigator)
    {
	    OnAbilityStopped(instigator);
    }

    // DELEGATES

    // Appelee quand l’ability est ajouter
    public virtual void OnAbilityAdded(GameObject instigator)
    {
	    bCanAdd = false;
	    bCanStart = true;
    }
    // Appelee quand l’ability est supprimer
    public virtual void OnAbilityRemoved(GameObject instigator)
    {
	    bCanAdd = true;
	    bCanStart = false;
    }
    // Appelee quand l’ability demarre
    public virtual void OnAbilityStarted(GameObject instigator)
    {
	    bCanStart = false;

    }
    // Appelee quand l’ability arrete
    public virtual void OnAbilityStopped(GameObject instigator)
    {
	    bCanStart = true;
    }
    // Appelee pour savoir si l’ability peut demarrer
    public virtual bool CanStartAbility(GameObject instigator)
    {
	    if (bCanStart)// and instigator doesnt have blocking effect tag
	    {
		    return true;

	    }

	    return false;

    }
    // Appelee pour savoir si l’ability peut s’ajouter a un component
    public virtual bool CanAddAbility(GameObject instigator)
    {
	    return bCanAdd;
    }
}
