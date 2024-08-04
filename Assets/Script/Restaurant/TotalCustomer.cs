using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Restaurant
{
    public class TotalCustomer : MonoBehaviour
    {
        private int totalCustomer = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) // debugging
            {
                totalCustomer = 50;
            }
        }

        public void AddCustomerCounter()
        {
            totalCustomer++;
        }


        public int GetTotalCustomer() { return totalCustomer; }
    }

}