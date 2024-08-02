using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Openning;

namespace TestBR.Planning
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Effect/Gold Effect", order = 1)]
    public class GoldEffect : ShopEffectSO
    {
        [SerializeField] float modifierPercenntage;

        private OpeningMechanic openingMechanic;

        public override void ActivateEffect()
        {
            openingMechanic = FindAnyObjectByType<OpeningMechanic>();

            openingMechanic.SetModifierPercentage(Core.StatsEnum.Gold, modifierPercenntage);
        }
    }

}