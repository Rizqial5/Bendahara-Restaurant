using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.NPC;
using TestBR.Restaurant;

namespace TestBR.Openning
{
    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject npcPrefab;
        [SerializeField] private GameObject carPrefab;
        [SerializeField] private Transform[] spawnLocations;
        [SerializeField] private Transform[] carLocations;
        [SerializeField] private TotalCustomer totalCustomer;
        [SerializeField] private DoorMechanic restaurantDoor;

        private OpeningMechanic openingMechanic;
        

        private void Awake()
        {
            openingMechanic = FindAnyObjectByType<OpeningMechanic>();
        }

        

        public void GenerateNPC()
        {
            int spawnLocationIndex = Random.Range(0, spawnLocations.Length);
            int targetPoisitionIndex = 0;


            GameObject spawnedNpc = Instantiate(npcPrefab, spawnLocations[spawnLocationIndex].position, Quaternion.identity);

            
            

            if(spawnLocationIndex == 0)
            {
                targetPoisitionIndex = 1;

            }else if(spawnLocationIndex == 1)
            {
                targetPoisitionIndex = 0;
            }

            spawnedNpc.GetComponent<OnRestoBehaviour>().onRestoDone.AddListener(openingMechanic.NpcPayments);
            spawnedNpc.GetComponent<OnRestoBehaviour>().onRestoDone.AddListener(totalCustomer.AddCustomerCounter);

            spawnedNpc.GetComponent<OnRestoBehaviour>().onEnterResto.AddListener(restaurantDoor.StartDoorOpen);

            spawnedNpc.GetComponent<NpcMover>().SetTarget(spawnLocations[targetPoisitionIndex]);
            spawnedNpc.GetComponent<NpcMover>().SetInitialTarget(spawnLocations[targetPoisitionIndex]);
        }

        public void RepeatSpawnCars()
        {
            InvokeRepeating("GenerateCars", 5, 5);
        }

        public void GenerateCars()
        {
            int spawnLocationIndex = Random.Range(0, spawnLocations.Length);
            int targetPoisitionIndex = 0;


            GameObject spawnedCar = Instantiate(carPrefab, carLocations[spawnLocationIndex].position, Quaternion.identity);

            


            if (spawnLocationIndex == 0)
            {
                targetPoisitionIndex = 1;

            }
            else if (spawnLocationIndex == 1)
            {
                targetPoisitionIndex = 0;
            }

            spawnedCar.GetComponent<CarMover>().SetTarget(carLocations[targetPoisitionIndex]);
            
        }
    }
}
