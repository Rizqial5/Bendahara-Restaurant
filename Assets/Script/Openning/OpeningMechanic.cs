using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;

namespace TestBR.Openning
{
    public class OpeningMechanic : MonoBehaviour
    {
        [SerializeField] private NpcSpawner npcSpawner;
        [SerializeField] StatsSO resourcesDatabase;

        private float moneyModifier;
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

            print("Npc Membayar " + amount);

            resourcesDatabase.AddTotalSource(StatsEnum.Gold, amount + moneyModifier);

        }

        public DayTimer GetDayTimer() { return dayTimer; }
    }
}
