using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;
using TestBR.Mission;

namespace TestBR.Openning
{
    public class OpeningMechanic : MonoBehaviour
    {
        [SerializeField] private NpcSpawner npcSpawner;
        [SerializeField] StatsSO resourcesDatabase;
        [SerializeField] private RecapMechanic recapMechanic;


        private float moneyModifier;
        private float foodModifier;
        private float baseModifier = 0;
        
        

        private DayTimer dayTimer;



        private void Awake()
        {
            dayTimer = GetComponent<DayTimer>();
            
        }

        public NpcSpawner GetNpcSpawner()
        { return npcSpawner; }

        public void NpcPayments()
        {
            float amount = 10; //dummy
            float foodDecreaseAmount = -5;

            

            float totalMoneyModifier = amount * ( moneyModifier / 100);

            float totalMoneyApplied = amount + totalMoneyModifier;

            resourcesDatabase.AddTotalSource(StatsEnum.Gold, totalMoneyApplied);
            recapMechanic.AddGoldToday(totalMoneyApplied);

            resourcesDatabase.AddTotalSource(StatsEnum.FoodIngredients, foodDecreaseAmount);

            print("Npc Membayar " + totalMoneyApplied);

        }

        public void SetModifierPercentage(StatsEnum statsEnum, float modifierValue)
        {
           
            if(statsEnum == StatsEnum.Gold)
            {
                moneyModifier = modifierValue;
            }
            
        }

        

        public StatsSO GetResourcesDatabase() { return resourcesDatabase; }
        public DayTimer GetDayTimer() { return dayTimer; }
        public RecapMechanic GetRecapMechanic() { return recapMechanic; }
        
    }
}
