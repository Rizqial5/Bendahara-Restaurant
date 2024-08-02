using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Planning;
using TestBR.Core;

namespace TestBR.Mission
{

    [CreateAssetMenu(fileName = "Mission", menuName = "Mission/Check Mission/Check Gold Mission", order = 1)]
    public class CheckGoldMission : CheckMissionSO
    {

        [SerializeField] float targetGold;
        [SerializeField] float rewardGold;

        private float currentGold;

       
        private string currentGoldDesc;

        public CheckGoldMission(StatsSO resourceDatabase) : base(resourceDatabase)
        {
        }

        public override bool CheckCompleteMission()
        {
            

            currentGold = resourceDatabase.GetTotalSource(StatsEnum.Gold);

            currentGoldDesc = "Current Gold : " + currentGold;

            if(currentGold >= targetGold)
            {
                return true;
            }

            return false;
        }

        public override string MissionProgress()
        {

            return currentGoldDesc;
        }

        public override void ResetValues()
        {
            currentGold = 0;
        }

        public override void GetRewardCompleted()
        {
            resourceDatabase.AddTotalSource(StatsEnum.Gold, rewardGold);
        }


    }
}
