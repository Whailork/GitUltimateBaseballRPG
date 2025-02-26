using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public Action<GameObject> addedDelegate;
    public Action<GameObject> removedDelegate;
    public float duration;
    public float period;
    public AttributeModifier attributeModifier;
    public bool bEffectExpired;
    public GameplayTag tagToAdd;
    public List<GameplayTag> blockingTags;
    public GameObject owner;
    public AttributeSystemComponent ownerAttributeSystemComponent;
    void Start()
    {
        addedDelegate += OnEffectAdded;
        removedDelegate += OnEffectRemoved;
        bEffectExpired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PeriodCoroutine ()
    {

        yield return new WaitForSeconds(period);
        OnEffectTriggered();
        if (!bEffectExpired)
        {
            StartCoroutine(PeriodCoroutine());
        }

    }
    IEnumerator DurationCoroutine()
    {

        yield return new WaitForSeconds(duration);
        StopPeriodTimer();

    }

    public virtual void OnEffectAdded(GameObject instigator)
    {
        owner = instigator;
        ownerAttributeSystemComponent = instigator.GetComponent<AttributeSystemComponent>();
        // le timer pour le période
        StartCoroutine(PeriodCoroutine());
        //le timer de duration pour trigger quand la duration de l'effet est atteinte
        StartCoroutine(DurationCoroutine());
    }
   

    public virtual void OnEffectRemoved(GameObject instigator)
    {
        StopCoroutine(PeriodCoroutine());
        StopCoroutine(DurationCoroutine());
    }

    public virtual void OnEffectTriggered()
    {
       
        float attributeValue = 0;
	
        ownerAttributeSystemComponent.GetAttributeValue(attributeModifier.targetAttribute,ref attributeValue);
        switch (attributeModifier.operation)
        {
            case EModifierOperation.Add :
                ownerAttributeSystemComponent.SetAttributeValue(attributeModifier.targetAttribute, +attributeValue + attributeModifier.value);
                break;
            case EModifierOperation.Substract :
                ownerAttributeSystemComponent.SetAttributeValue(attributeModifier.targetAttribute, +attributeValue - attributeModifier.value);
                break;
            case EModifierOperation.Multiply :
                ownerAttributeSystemComponent.SetAttributeValue(attributeModifier.targetAttribute, +attributeValue * attributeModifier.value);
                break;
            case EModifierOperation.Divide :
                ownerAttributeSystemComponent.SetAttributeValue(attributeModifier.targetAttribute, +attributeValue / attributeModifier.value);
                break;
        }
    }


    public virtual void StopPeriodTimer()
    {
        bEffectExpired = true;
        StopCoroutine(PeriodCoroutine());
    }
}

[Serializable]
public class AttributeModifier
{
    public float value;
    public GameplayTag targetAttribute;
    public EModifierOperation operation;
}

[Serializable]
public enum EModifierOperation {Add,Substract,Multiply,Divide }
