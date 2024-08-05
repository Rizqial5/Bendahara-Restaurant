using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Restaurant
{
    public class TotalCustomer : MonoBehaviour
    {
        private int totalCustomer = 0;

        

        public void AddCustomerCounter()
        {
            totalCustomer++;
        }


        public int GetTotalCustomer() { return totalCustomer; }
    }

}