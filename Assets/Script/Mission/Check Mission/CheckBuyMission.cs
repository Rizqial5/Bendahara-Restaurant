using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Planning;
using TestBR.Core;

namespace TestBR.Mission
{

    [CreateAssetMenu(fileName = "Mission", menuName = "Mission/Check Mission/Check Buy Mission", order = 1)]
    public class CheckBuyMission : CheckMissionSO
    {

        [SerializeField] ShopObjectSO targetedShopObject;
        [SerializeField] float goldReward;

        private ShopMechannic shopMechannic;

        public CheckBuyMission(StatsSO resourceDatabase) : base(resourceDatabase)
        {
        }

        public override bool CheckCompleteMission()
        {
            shopMechannic = FindAnyObjectByType<ShopMechannic>();

            if (shopMechannic.GetBuyedLists() == null) return false;

            if (shopMechannic.GetBuyedLists().Contains(targetedShopObject))
            {
                return true;
            }

            return false;
        }

        public override void GetRewardCompleted()
        {

            resourceDatabase.AddTotalSource(StatsEnum.Gold, goldReward);
        }

        public override string MissionProgress()
        {
            return base.MissionProgress();
        }

        public override void ResetValues()
        {
            
        }
    }
}
