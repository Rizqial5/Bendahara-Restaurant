using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TestBR.NPC
{
    public class OnRestoBehaviour : MonoBehaviour
    {
        [SerializeField] float waitTimeOnResto = 2f;

        public UnityEvent onRestoDone;
        public UnityEvent onEnterResto;

        private SpriteRenderer spriteRenderer;


        private float restoTimer;

        private NpcMover npcMover;
        private bool isInResto;
        
        public bool isDone {  get; private set; }
        

        private void Awake()
        {
            npcMover = GetComponent<NpcMover>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!isInResto) return;

           
            StartRestoBehaviour();
            
        }

        public void StartRestoBehaviour()
        {

            restoTimer += Time.deltaTime;

            if(restoTimer >= 0.5f)
            {
                spriteRenderer.enabled = false;
            }

            if(restoTimer >= waitTimeOnResto)
            {
                

                npcMover.SetTarget(npcMover.GetInitialTarget());

                print("Makan Selesai");

                onRestoDone.Invoke();


                spriteRenderer.enabled = true;

                isInResto = false;
                isDone = true;
            }



            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.name == "Restaurant Door")
            {
                onEnterResto.Invoke();
                isInResto=true;
            }
        }

    }
}
