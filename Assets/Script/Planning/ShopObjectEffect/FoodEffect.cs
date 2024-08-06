using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using UnityEngine;

namespace TestBR.Planning
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Effect/Base Food Effect", order = 1)]
    public class FoodEffect : ShopEffectSO
    {
        [SerializeField] float foodDecreaseAmount;

        private OpeningMechanic openingMechanic;

        public override void ActivateEffect()
        {
            openingMechanic = FindAnyObjectByType<OpeningMechanic>();

            openingMechanic.AddBaseFoodDecreases(foodDecreaseAmount);
        }

        public override string GetEffectDescription()
        {
            return "Menambahkan kebutuhan makanan " + foodDecreaseAmount + " per Customer";
        }
    }
}
