using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Planning
{
    public class PlanningMechanic : MonoBehaviour
    {

        [SerializeField] GameObject planningUI;

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
    }
}
