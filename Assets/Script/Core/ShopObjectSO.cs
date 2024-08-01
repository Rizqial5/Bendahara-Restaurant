using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using UnityEngine;

namespace TestBR.Core
{
    
    public class ShopObjectSO : ScriptableObject
    {
        [SerializeField] string objectName;
        [SerializeField] float priceAmount;
        [SerializeField] ModifierEffect[] modifierEffects;
        

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

        public void BuildLookupTable()
        {
            if (modifierDictionary != null) return;

            modifierDictionary = new Dictionary<StatsEnum, float>();

            foreach (ModifierEffect modifierAttributes in modifierEffects)
            {
                modifierDictionary[modifierAttributes.resourceCategory] = modifierAttributes.effectModifier;
            }
        }

        public void ActivateEffect()
        {
            BuildLookupTable();

            if (modifierDictionary == null) return;

            openingMechanic = FindAnyObjectByType<OpeningMechanic>();

            openingMechanic.SetModifierPercentage(modifierDictionary);

        }

        public float GetModiiferPercentage(StatsEnum statsEnum)
        {
            return modifierDictionary[statsEnum];
        }
        
        
    }


    [System.Serializable]
    public class ModifierEffect
    {
        [SerializeField] public StatsEnum resourceCategory;
        [SerializeField] public float effectModifier;

       
    }
}
