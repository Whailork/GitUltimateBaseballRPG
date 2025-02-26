using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Singletons
{
   public class GameplayTags 
   {
      private static GameplayTags GameplayTagsInstance;
      public Dictionary<string,GameplayTag> GameplayTagList;
      
      private GameplayTags()
      {
         GameplayTagsInstance = this;
         GameplayTagList = new Dictionary<string, GameplayTag>();
         
        LoadGameplayTags();
      }

      
      public static GameplayTags GetGameplayTagsInstance()
      {
         if (GameplayTagsInstance == null)
         {
            GameplayTagsInstance = new GameplayTags();
         }

         return GameplayTagsInstance;
      }
      public void LoadGameplayTags()
      {
         string[] assetNames = AssetDatabase.FindAssets("t:GameplayTag", new[] { "Assets/Scripts/SciptableObjects/GameplayTags" });
         GameplayTagsInstance.GameplayTagList.Clear();
         foreach (string SOName in assetNames)
         {
            var SOpath= AssetDatabase.GUIDToAssetPath(SOName);
            GameplayTag gTag = AssetDatabase.LoadAssetAtPath<GameplayTag>(SOpath);
            GameplayTagList.Add(gTag.tagName,gTag);
         }
      }
      
   }

  
}

