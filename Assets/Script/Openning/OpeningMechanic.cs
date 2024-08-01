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

            resourcesDatabase.AddTotalSource(StatsEnum.FoodIngredients, foodDecreaseAmount);

            print("Npc Membayar " + totalMoneyApplied);

        }

        public void SetModifierPercentage(Dictionary<StatsEnum,float> effectModifier)
        {

            foreach (var item in effectModifier)
            {
                if(item.Key == StatsEnum.Gold)
                {
                    if (moneyModifier != baseModifier) return;

                    moneyModifier = effectModifier[StatsEnum.Gold];
                    print("Money modifier ditambahkan " + moneyModifier + " persen");


                }
                else if(item.Key == StatsEnum.FoodIngredients)
                {
                    if (foodModifier != baseModifier) return;

                    foodModifier = effectModifier[StatsEnum.FoodIngredients];
                }
            }

            
        }

        

        public StatsSO GetResourcesDatabase() { return resourcesDatabase; }
        public DayTimer GetDayTimer() { return dayTimer; }
        
    }
}
