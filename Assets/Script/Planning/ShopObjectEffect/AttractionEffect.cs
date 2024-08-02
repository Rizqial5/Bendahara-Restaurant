using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Restaurant;

namespace TestBR.Planning
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Effect/Attraction Effect", order = 1)]
    public class AttractionEffect : ShopEffectSO
    {
        [SerializeField] float effectPercentageValue;


        private AttractMechanic attractMechanic;
        public override void ActivateEffect()
        {
            attractMechanic = FindAnyObjectByType<AttractMechanic>();

            

            attractMechanic.SetProbabiltyModifier(effectPercentageValue);
            
        }
    }
}
