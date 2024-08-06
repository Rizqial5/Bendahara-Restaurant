using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using TestBR.UI;
using TMPro;
using UnityEngine;

namespace TestBR.Planning
{
    public class ResourceAllocation : MonoBehaviour
    {
        [SerializeField] StatsSO resourcesDatabase;

        private float baseSpendingGold = -200;
        private float baseGetFood = 100;

        private float totalSpendingGold;
        private float totalGetFood;

        private float baseSpendingModifier;
        private float baseSpendingTotal;

        private GoldReport goldReport;

        [SerializeField] TextMeshProUGUI spendingGoldText;
        [SerializeField] TextMeshProUGUI getFoodText;
        [SerializeField] TextMeshProUGUI allocationLevelText;
        [SerializeField] GameObject allocationPanel;
        [SerializeField] NotifSystem notifSystem;

        private int allocationLevel = 1;

        private bool isNotifAppeared = false;

        private void Awake()
        {
            goldReport = GetComponent<GoldReport>();
        }
        public void StarAllocation()
        {
            if (goldReport.GetTotalGold() < 0) return;
            resourcesDatabase.AddTotalSource(StatsEnum.FoodIngredients, totalGetFood);
        }

        public void FoodAllocations()
        {
            baseSpendingTotal = baseSpendingGold + (baseSpendingGold * baseSpendingModifier / 100);

            totalSpendingGold = baseSpendingTotal * allocationLevel;

            totalGetFood = baseGetFood * allocationLevel;
        }

        public void AddAllocationLevel(int addedLevel) // digunakan dibutton allocationnya
        {
            int oldAllocation = allocationLevel;

            allocationLevel += addedLevel;
           

            if(allocationLevel<0)
            {
                allocationLevel = 0;
            }
            else if(allocationLevel > 3)
            {
                allocationLevel = 3;
            }

            if(oldAllocation != allocationLevel)
            {
                FoodAllocations();
                goldReport.ShowFormulation();
                goldReport.ShowResourceUI();
            }
            

            spendingGoldText.text = totalSpendingGold.ToString();
            getFoodText.text = totalGetFood.ToString();
            allocationLevelText.text = allocationLevel.ToString();
        }

        

        

        public void ShowAllocationUI()
        {

            if (allocationPanel.activeInHierarchy)
            {

               

                allocationPanel.SetActive(false);


                return;
            }

            allocationPanel.SetActive(true);

            
            FoodAllocations();
            goldReport.ShowFormulation();
            goldReport.ShowResourceUI();


            spendingGoldText.text = totalSpendingGold.ToString();
            getFoodText.text = totalGetFood.ToString();
            allocationLevelText.text = allocationLevel.ToString();
        }

        public void SetPriceModifier(float setModifier)
        {
            baseSpendingModifier = setModifier;
        }

        public float GetSpendingGold()
        { return baseSpendingGold; }

        public float GetFoodGained()
        { return baseGetFood; }

        public float GetTotalSpendingGold()
        {
            return totalSpendingGold;
        }
    }
}
