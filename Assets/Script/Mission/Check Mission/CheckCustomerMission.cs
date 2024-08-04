using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Restaurant;
using TestBR.Core;

namespace TestBR.Mission
{

    [CreateAssetMenu(fileName = "Mission", menuName = "Mission/Check Mission/Check Customer Mission", order = 1)]
    public class CheckCustomerMission : CheckMissionSO
    {
        [SerializeField] int targetTotalCustomer;

        [SerializeField] float probabiltyValueAddition;


        private TotalCustomer totalCustomer;
        private AttractMechanic attractMechanic;

        public CheckCustomerMission(StatsSO resourceDatabase) : base(resourceDatabase)
        {
        }

        public override bool CheckCompleteMission()
        {
            totalCustomer = FindAnyObjectByType<TotalCustomer>();

            if(totalCustomer.GetTotalCustomer() >= targetTotalCustomer)
            {
                return true;
            }

            return false;
        }

        public override void GetRewardCompleted()
        {
            attractMechanic = FindAnyObjectByType<AttractMechanic>();

            attractMechanic.AddProbabilityModifier(probabiltyValueAddition);
        }

        public override string MissionProgress()
        {
            totalCustomer = FindAnyObjectByType<TotalCustomer>();

            return totalCustomer.GetTotalCustomer().ToString();
        }

        public override void ResetValues()
        {
            base.ResetValues();
        }
    }
}
