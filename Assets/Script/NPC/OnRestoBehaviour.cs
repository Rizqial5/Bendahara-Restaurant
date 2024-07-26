using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.NPC
{
    public class OnRestoBehaviour : MonoBehaviour
    {
        [SerializeField] float waitTimeOnResto = 2f;


        private float restoTimer;

        private NpcMover npcMover;
        private bool isInResto;
        public bool isDone {  get; private set; }
        

        private void Awake()
        {
            npcMover = GetComponent<NpcMover>();
        }

        private void Update()
        {
            if (!isInResto) return;

           
            StartRestoBehaviour();
            
        }

        public void StartRestoBehaviour()
        {

            restoTimer += Time.deltaTime;

            if(restoTimer >= waitTimeOnResto)
            {
                

                npcMover.SetTarget(npcMover.GetInitialTarget());

                print("Makan Selesai");

                
                isInResto = false;
                isDone = true;
            }



            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.name == "Restaurant Door")
            {
                isInResto=true;
            }
        }

    }
}
