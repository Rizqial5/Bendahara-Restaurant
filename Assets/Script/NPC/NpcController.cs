using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.NPC
{
    public class NpcController : MonoBehaviour
    {
        
        private NpcMover npcMover;
        private OnRestoBehaviour restoBehaviour;

        private string targetTagLocation;

        private void Awake()
        {
            restoBehaviour = GetComponent<OnRestoBehaviour>();
            npcMover = GetComponent<NpcMover>();
        }

        private void Update()
        {
            if(npcMover.HasReachedCurrentTarget(npcMover.GetInitialTarget()))
            {
                Destroy(gameObject, 0.2f);
            }
        }

        public bool GetNpcIsDone()
        {
            return restoBehaviour.isDone;
        }

        public void SetNPCTarget(string targetTag)
        {
            targetTagLocation = targetTag;
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == targetTagLocation)
            {
                Destroy(gameObject, 0.2f);
            }


        }

    }
}
