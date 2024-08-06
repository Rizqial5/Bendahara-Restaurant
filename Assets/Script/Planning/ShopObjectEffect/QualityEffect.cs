using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using UnityEngine;

namespace TestBR.Planning
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Effect/Base Price Effect", order = 1)]
    public class QualityEffect : ShopEffectSO
    {
        [SerializeField] private float addBaseGoldPayment;
        private OpeningMechanic openingMechanic;

        public override void ActivateEffect()
        {
            openingMechanic = FindAnyObjectByType<OpeningMechanic>();

            openingMechanic.AddBaseGoldPayment(addBaseGoldPayment);
        }

       

        public override string GetEffectDescription()
        {
            string effectDesc = "Menambahkan harga makanan sejumalah " + addBaseGoldPayment + " Gold";

            return effectDesc;
        }

       

        
    }
}
