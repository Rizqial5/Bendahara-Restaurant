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
        [SerializeField] Sprite adImage;
        [SerializeField] Sprite shopIcon;

        [SerializeField] float priceAmount;
        [SerializeField] float maintenanceCost;

        [SerializeField] List<ShopEffectSO> positiveObjectEffects;
        [SerializeField] List<ShopEffectSO> negativeObjectEffects;


        [TextArea(2, 8)]
        [SerializeField] private string descriptionText;

        private OpeningMechanic openingMechanic;
        private PlanningMechanic planningMechanic;
        private Dictionary<StatsEnum, float> modifierDictionary;

        public string GetObjectName()
        {  return objectName; }

        public string GetDescriptionText()
        { return descriptionText; }

        public float GetPrice()
        { return priceAmount; }

        public float GetMaintenanceCost()
        {  return maintenanceCost; }

        public Sprite GetIcon() { return shopIcon; }

        public Sprite GetAdImage() { return adImage; }
        public void ActivateEffect()
        {
            foreach (ShopEffectSO item in positiveObjectEffects)
            {
                item.ActivateEffect();
            }
          
        }

        public List<string> GetShopEffectsDescription()
        {
            List<string> results = new List<string>();

            foreach (ShopEffectSO item in positiveObjectEffects)
            {
                results.Add(item.GetEffectDescription());
            }

            return results;
        }

        public void SetMaintenanceCost()
        {
            planningMechanic = FindAnyObjectByType<PlanningMechanic>();

            Debug.Log("Maintenance telah ditambahkan " + maintenanceCost);

            planningMechanic.GetGoldReport().AddMaintenanceCost(maintenanceCost);
        }

        public float GetModiiferPercentage(StatsEnum statsEnum)
        {
            return modifierDictionary[statsEnum];
        }
        
        
    }


   
}
