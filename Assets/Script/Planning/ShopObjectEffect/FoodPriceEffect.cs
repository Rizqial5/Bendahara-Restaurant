using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;

namespace TestBR.Planning
{
    [CreateAssetMenu(fileName = "Shop", menuName = "Shop/Shop Effect/Food Price Effect", order = 1)]
    public class FoodPriceEffect : ShopEffectSO
    {
        [SerializeField] float priceModifierPercentage;
        [SerializeField] int durationDays;

        private bool isNotifAppeared = false;

        private ResourceAllocation resourceAllocation;
        private NotifSystem notifSystem;

        public override void ActivateEffect()
        {
            notifSystem = FindAnyObjectByType<NotifSystem>();

            if (durationDays <= 0)
            {
                resourceAllocation.SetPriceModifier(0);

                if (isNotifAppeared) return;
               
                notifSystem.StartNotif("Effect telah kembali ke semula");
                isNotifAppeared=true;

                return;
            }

            resourceAllocation = FindAnyObjectByType<ResourceAllocation>();

            resourceAllocation.SetPriceModifier(priceModifierPercentage);
        }

        public override string GetEffectDescription()
        {
            string effecDesc = "Meningkatkan harga ingredients sebanyak " + priceModifierPercentage + "%";

            return effecDesc;
        }


        public override void SetDurationTimer()
        {
            
            if (durationDays <= 0) return;
            durationDays--;
        }

        public override void ResetValues()
        {
            durationDays = 3;
            isNotifAppeared = false;
        }
    }
}
