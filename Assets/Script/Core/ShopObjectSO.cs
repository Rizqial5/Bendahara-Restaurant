using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Core
{
    
    public class ShopObjectSO : ScriptableObject
    {
        [SerializeField] string objectName;
        [SerializeField] float priceAmount;

        

        [TextArea(2, 8)]
        [SerializeField] private string descriptionText;

        

        public string GetObjectName()
        {  return objectName; }

        public string GetDescriptionText()
        { return descriptionText; }

        public float GetPrice()
        { return priceAmount; }
       

        
        
    }
}
