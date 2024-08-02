using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using TestBR.Planning;
using UnityEngine;

namespace TestBR.Core
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Object", order = 1)]
    public class ShopObjectSO : ScriptableObject
    {
        [SerializeField] string objectName;
        [SerializeField] ShopEnum shopEnum;

        [SerializeField] float priceAmount;
        [SerializeField] List<ShopEffectSO> objectEffects;
        

        [TextArea(2, 8)]
        [SerializeField] private string descriptionText;

        private OpeningMechanic openingMechanic;
        private Dictionary<StatsEnum, float> modifierDictionary;

        public string GetObjectName()
        {  return objectName; }

        public string GetDescriptionText()
        { return descriptionText; }

        public float GetPrice()
        { return priceAmount; }

       

        public void ActivateEffect()
        {
            foreach (ShopEffectSO item in objectEffects)
            {
                item.ActivateEffect();
            }
          
        }

        public float GetModiiferPercentage(StatsEnum statsEnum)
        {
            return modifierDictionary[statsEnum];
        }
        
        
    }


   
}
