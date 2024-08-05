using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestBR.Openning
{
    public class RecapMechanic : MonoBehaviour
    {
        private int totalCustomerToday;
        private float totalGoldToday;

        [SerializeField] GameObject recapPanel;

        [SerializeField] TextMeshProUGUI showTotalCustomer;
        [SerializeField] TextMeshProUGUI showTotalGoldToday;

        public void AddTotalCustomerToday()
        {
            totalCustomerToday++;        
        }

        public void AddGoldToday(float addedGold)
        {
            totalGoldToday += addedGold;
        }

        public void ResetRecap()
        {
            totalCustomerToday = 0;
            totalGoldToday = 0;
        }

        public void ShowRecapPanel()
        {
            recapPanel.SetActive(true);

            showTotalCustomer.text = "Total Customer : " + totalCustomerToday;
            showTotalGoldToday.text = "Total Gold gained : " + totalGoldToday;
        }

        public void ClosePanel()
        {
            recapPanel.SetActive(false);
        }
    }
}
