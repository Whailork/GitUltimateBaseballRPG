using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class AttributeUI : MonoBehaviour
{
     public GameplayTag linkedAttribute;     
     public GameObject linkedObject;

     public GameObject thisUi;
     // Start is called before the first frame update

     void Start()
    {
        if (linkedObject.GetComponent<AttributeSystemComponent>().AttributeChangedDelegates.ContainsKey(linkedAttribute))
        {
            linkedObject.GetComponent<AttributeSystemComponent>().AttributeChangedDelegates[linkedAttribute] += UpdateValue;
        }
        else
        {
            linkedObject.GetComponent<AttributeSystemComponent>().AttributeChangedDelegates.Add(linkedAttribute,null);
            linkedObject.GetComponent<AttributeSystemComponent>().AttributeChangedDelegates[linkedAttribute] += UpdateValue;
        }
        
        //on set les values min, current et max
        float outValue = 0;
        if (linkedObject.GetComponent<AttributeSystemComponent>().GetAttributeMinValue(linkedAttribute,ref outValue))
        {
            thisUi.GetComponent<Slider>().minValue = outValue;
        }
        if (linkedObject.GetComponent<AttributeSystemComponent>().GetAttributeMaxValue(linkedAttribute,ref outValue))
        {
            thisUi.GetComponent<Slider>().maxValue = outValue;
        }
        if (linkedObject.GetComponent<AttributeSystemComponent>().GetAttributeValue(linkedAttribute,ref outValue))
        {
            thisUi.GetComponent<Slider>().value = outValue;
        }
        

    }

    public void UpdateValue(string gTag, float min, float current, float max)
    {
        if (gTag == linkedAttribute.tagName)
        {
            thisUi.GetComponent<Slider>().minValue = min;
            thisUi.GetComponent<Slider>().value = current;
            thisUi.GetComponent<Slider>().maxValue = max;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
