using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SciptableObjects.Attributes;
using Singletons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AttributeSystemComponent : MonoBehaviour
{
    
    public List<Attribute> Attributes;

    public DefaultAttributes DefaultAttributes;
    //tag,min,current,max
    public Dictionary<GameplayTag, Action<string,float,float,float>> AttributeChangedDelegates;

    public AttributeSystemComponent()
    {
        AttributeChangedDelegates = new Dictionary<GameplayTag, Action<string, float, float, float>>();
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        // on load les attributs par défault
        if (DefaultAttributes != null)
        {
            foreach (Attribute attribute in DefaultAttributes.Attributes)
            {
                AddAttribute(attribute);
            }
        }
    }

    void FixedUpdate()
    {
        /*float outValue = 0;
        if(GetAttributeValue(GameplayTags.GetGameplayTagsInstance().GameplayTagList["Health"], ref outValue))
        {
            outValue--;
            SetAttributeValue(GameplayTags.GetGameplayTagsInstance().GameplayTagList["Health"], outValue);
        }*/
        
    }
    
// Set new value to attribute with specific tag
    public bool SetAttributeValue(GameplayTag gameplayTag, float newValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outAttribute.Current = newValue;
            AttributeChangedDelegates[outAttribute.AttributeTag]?.Invoke(outAttribute.AttributeTag.tagName,outAttribute.Min,outAttribute.Current,outAttribute.Max);
            return true;
        }
        return false;
        
    } 

    public bool GetAttributeValue(GameplayTag gameplayTag, ref float outValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outValue = outAttribute.Current;
            return true;
        }
        return false;
        
    }

    public bool SetAttributeMaxValue(GameplayTag gameplayTag, float newValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outAttribute.Max = newValue;
            AttributeChangedDelegates[outAttribute.AttributeTag]?.Invoke(outAttribute.AttributeTag.tagName,outAttribute.Min,outAttribute.Current,outAttribute.Max);
            return true;
        }
        return false;
    }

    public bool GetAttributeMaxValue(GameplayTag gameplayTag, ref float outValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outValue = outAttribute.Max;
            return true;
        }
        return false;
    }

    public bool SetAttributeMinValue(GameplayTag gameplayTag, float newValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outAttribute.Min = newValue;
            AttributeChangedDelegates[outAttribute.AttributeTag]?.Invoke(outAttribute.AttributeTag.tagName,outAttribute.Min,outAttribute.Current,outAttribute.Max);
            return true;
        }
        return false;
    }

    public bool GetAttributeMinValue(GameplayTag gameplayTag, ref float outValue)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            outValue = outAttribute.Min;
            return true;
        }
        return false;
    }

    public bool HasAttribute(GameplayTag gameplayTag, ref Attribute outAttribute)
    {
        outAttribute = Attributes.FirstOrDefault(i => i.AttributeTag.tagName == gameplayTag.tagName);
        if (outAttribute != null)
        {
            return true;
        }

        return false;

    }
    public bool HasAttribute(GameplayTag gameplayTag)
    {
        Attribute attribute = Attributes.FirstOrDefault(i => i.AttributeTag.tagName == gameplayTag.tagName);
        if (attribute != null)
        {
            return true;
        }

        return false;

    }

    bool AddAttribute(Attribute newAttribute)
    {
        
        if (!HasAttribute(newAttribute.AttributeTag))
        {
            Attributes.Add(newAttribute);
            AttributeChangedDelegates.TryAdd(newAttribute.AttributeTag,null);
        }

        return false;
    }

    bool RemoveAttribute(GameplayTag gameplayTag)
    {
        Attribute outAttribute = new Attribute();
        if (HasAttribute(gameplayTag, ref outAttribute))
        {
            Attributes.Remove(outAttribute);
            AttributeChangedDelegates.Remove(outAttribute.AttributeTag);
            return true;
        }

        return false;
    }
   
}

[Serializable]
public class Attribute
{
    public GameplayTag AttributeTag;
    public float Min;
    public float Current;
    public float Max;
}