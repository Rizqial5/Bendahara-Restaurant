using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;

namespace TestBR.Planning
{
    public class PlanningMechanic : MonoBehaviour
    {

        [SerializeField] GameObject planningUI;
        [SerializeField] StatsSO resourcesDatabase;
        [SerializeField] ShopMechannic shopMechannic;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


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

        public StatsSO GetResourcesDatabase()
        { return resourcesDatabase; }

        
    }
}
