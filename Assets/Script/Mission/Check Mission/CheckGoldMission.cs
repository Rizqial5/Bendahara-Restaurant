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

        private float currentGold;

        private PlanningMechanic planningMechanic;
        private StatsSO resourcesDatabase;
        private string currentGoldDesc;

        public override bool CheckCompleteMission()
        {
            planningMechanic = FindAnyObjectByType<PlanningMechanic>();

            resourcesDatabase = planningMechanic.GetResourcesDatabase();

            currentGold = resourcesDatabase.GetTotalSource(StatsEnum.Gold);

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



    }
}
