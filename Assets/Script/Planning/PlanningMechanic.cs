using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;
using TestBR.Mission;

namespace TestBR.Planning
{
    public class PlanningMechanic : MonoBehaviour
    {

        [SerializeField] GameObject planningUI;
        [SerializeField] StatsSO resourcesDatabase;
        [SerializeField] ShopMechannic shopMechannic;
        [SerializeField] MissionManager missionManager;
        [SerializeField] ResourceAllocation resourceAllocation;
        [SerializeField] GoldReport goldReport;

        


        public void PlayOpening()
        {
            planningUI.SetActive(false);
        }

        public void ActivePlanning()
        {
            planningUI.SetActive(true);
        }

        public List<ShopObjectSO> GetBuyedObjectLists()
        {
            return shopMechannic.GetBuyedLists();
        }

        public ShopMechannic GetShopMechannic()
        { return shopMechannic; }
        
        public MissionManager GetMissionManager()
        {
            return missionManager;
        }

        public GoldReport GetGoldReport()
        { return goldReport; }

        public ResourceAllocation GetResourceAllocation()
        {
            return resourceAllocation;
        }

        public StatsSO GetResourcesDatabase()
        { return resourcesDatabase; }

        
    }
}
