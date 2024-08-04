using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using TMPro;
using UnityEngine;

namespace TestBR.Planning
{
    public class GoldReport : MonoBehaviour
    {
        [SerializeField] StatsSO resourcesDatabase;


        [SerializeField] TextMeshProUGUI ingredientsSpendText;
        [SerializeField] TextMeshProUGUI maintenanceSpendText;
        [SerializeField] TextMeshProUGUI currentGoldText;
        [SerializeField] TextMeshProUGUI totalGoldText;


        private ResourceAllocation resourceAllocation;

        private float ingredientSpend;
        private float maintenanceSpend;
        private float currentGold;
        private float totalGold;
        private float maintenanceSpendAddtion;

        private void Awake()
        {
            resourceAllocation = GetComponent<ResourceAllocation>();
        }

        public void ShowFormulation()
        {
            BuildResource();

            totalGold = currentGold + (ingredientSpend + maintenanceSpend);

            
        }

        public void ShowResourceUI()
        {
            ingredientsSpendText.text = "Ingredients :  " + ingredientSpend;
            maintenanceSpendText.text = "Maintenance : " + maintenanceSpend;
            currentGoldText.text = "Current Gold : " + currentGold; 
            totalGoldText.text = "Total Gold : " + totalGold;
        }

        private void BuildResource()
        {
            currentGold = resourcesDatabase.GetTotalSource(StatsEnum.Gold);
            ingredientSpend = resourceAllocation.GetTotalSpendingGold();
            maintenanceSpend = -50 + maintenanceSpendAddtion;
        }

        public void AddFormulation()
        {
            resourcesDatabase.SetTotalSource(StatsEnum.Gold, totalGold);
        }

        public void AddMaintenanceCost(float addAmount)
        {
            maintenanceSpendAddtion += addAmount;

            
        }
    }
}
