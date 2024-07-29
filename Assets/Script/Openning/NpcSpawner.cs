using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.NPC;

namespace TestBR.Openning
{
    public class NpcSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject npcPrefab;
        [SerializeField] private Transform[] spawnLocations;

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

            spawnedNpc.GetComponent<NpcMover>().SetTarget(spawnLocations[targetPoisitionIndex]);
            spawnedNpc.GetComponent<NpcMover>().SetInitialTarget(spawnLocations[targetPoisitionIndex]);
        }
    }
}
