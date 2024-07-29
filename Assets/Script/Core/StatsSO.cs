using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Core
{
    [CreateAssetMenu(fileName = "Resources", menuName = "ResourcesDatabase", order = 1)]
    public class StatsSO : ScriptableObject
    {
        [SerializeField] StatsSource[] statsSource;

        private Dictionary<StatsEnum, float > resourcesLookUpTable;

        public void BuildLookupTable()
        {
            if (resourcesLookUpTable != null) return;

            resourcesLookUpTable = new Dictionary<StatsEnum, float>();

            foreach (StatsSource sourcesAttributes in statsSource)
            {
                resourcesLookUpTable[sourcesAttributes.resourceCategory] = sourcesAttributes.totalAmount;
            }
        }

        public float GetTotalSource(StatsEnum resourceCategory)
        {
            BuildLookupTable();


            return resourcesLookUpTable[resourceCategory];
        }

        public void AddTotalSource(StatsEnum resourceCategory, float addAmount)
        {

            resourcesLookUpTable[resourceCategory] += addAmount;
                    
        }

        

    }


    [System.Serializable]
    public class StatsSource
    {
        [SerializeField] public StatsEnum resourceCategory;
        [SerializeField] public float totalAmount;
    }
}
