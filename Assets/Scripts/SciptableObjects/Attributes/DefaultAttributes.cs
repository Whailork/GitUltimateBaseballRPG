using System.Collections.Generic;
using UnityEngine;

namespace SciptableObjects.Attributes
{
    [CreateAssetMenu(menuName = "DefaultAttributes/new DefaultAttributes",fileName = "DefaultAttributes_Null",order = 0)]
    public class DefaultAttributes : ScriptableObject
    {
        public  List<Attribute> Attributes;

   
        
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
