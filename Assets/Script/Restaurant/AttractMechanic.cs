using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using UnityEngine;

namespace TestBR.Restaurant
{
    public class AttractMechanic : MonoBehaviour
    {
        [Range(0,1)]
        [SerializeField] private float probability;

        [SerializeField] private Transform restaurantPosition;

        [SerializeField] StatsSO resourcesDatabase;

        void Update()
        {
           
        }


        public bool CheckProbability()
        {
            // Hasilkan angka acak antara 0 dan 1
            float randomValue = Random.Range(0f, 1f);

            // Bandingkan angka acak dengan probabilitas
            return randomValue <= probability;
        }

        
        public StatsSO GetResourcesDatabase()
        {

            return resourcesDatabase; 
        
        }

        public Transform GetRestoPosition()
        { return restaurantPosition; }

       
    }
}
