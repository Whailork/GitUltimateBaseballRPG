using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GameplayTag/new GameplayTag",fileName = "GameplayTag_Null",order = 0)]
[Serializable]
public class GameplayTag : ScriptableObject
{
    public string tagName;
    public GameplayTag parent;
    public GameplayTag(string tagName, GameplayTag parent)
    {
        this.tagName = tagName;
        this.parent = parent;
    }

    public string GetFullName()
    {
        string fullName = tagName;
        GameplayTag currentParent = parent;
        while (currentParent != null)
        {
            fullName = fullName + "/" + currentParent.tagName;
            currentParent = currentParent.parent;
        }

        return fullName;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
