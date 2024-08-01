using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Core;
using TMPro;

namespace TestBR.UI
{
    public class ResourcePanel : MonoBehaviour
    {
        [Header("Resources Database")]
        [SerializeField] StatsSO resourcesDatabase;

        [Header("Text")]
        [SerializeField] TextMeshProUGUI goldAmount;
        [SerializeField] TextMeshProUGUI ingredientAmount;


        private void Start()
        {
            goldAmount.text = resourcesDatabase.GetTotalSource(StatsEnum.Gold).ToString();
            ingredientAmount.text = resourcesDatabase.GetTotalSource(StatsEnum.FoodIngredients).ToString();
        }

        private void Update()
        {
            goldAmount.text = resourcesDatabase.GetTotalSource(StatsEnum.Gold).ToString();
            ingredientAmount.text = resourcesDatabase.GetTotalSource(StatsEnum.FoodIngredients).ToString();
        }


    }
}
