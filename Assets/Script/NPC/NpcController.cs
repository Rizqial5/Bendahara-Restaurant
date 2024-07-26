using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.NPC
{
    public class NpcController : MonoBehaviour
    {
        
        private NpcMover npcMover;
        private OnRestoBehaviour restoBehaviour;

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



    }
}
