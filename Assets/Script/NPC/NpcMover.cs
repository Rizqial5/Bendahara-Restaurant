using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TestBR.NPC
{
    public class NpcMover : MonoBehaviour
    {

        private NavMeshAgent npcAgent;

        private Transform initalTarget;  //target sebelum masuk ke resto

        private Transform targetNow;

        private float NPCPosX = 0;

        private void Awake()
        {
            npcAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            

            npcAgent.updateRotation = false;
            npcAgent.updateUpAxis = false;

            

        }

        private void Update()
        {
            

            



            if (HasReachedTarget())
            {
                
                npcAgent.isStopped = true;
                
            }
            else
            {
                npcAgent.isStopped = false;
            }

            
        }


        public void NpcXPosition()
        {
            if (npcAgent.velocity.x < 0)
            {
                NPCPosX = -1;

            }
            else if (npcAgent.velocity.x > 0)
            {
                NPCPosX = 1;
            }
        }


        public void SetTarget(Transform target)
        {
            targetNow = target;

            
            npcAgent.SetDestination(target.position);

            

            
        }

        public void SetInitialTarget(Transform target)
        {
            initalTarget = target;
        }

        public Transform GetInitialTarget()
        { return initalTarget; }

        public bool HasReachedTarget()
        {
            if (!npcAgent.pathPending)
            {
                if (npcAgent.remainingDistance <= npcAgent.stoppingDistance)
                {
                    if (!npcAgent.hasPath || npcAgent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasReachedCurrentTarget(Transform target)
        {

            float yDestination = Mathf.Round(npcAgent.destination.y);
            float yTarget = Mathf.Round(target.position.y);

            if (HasReachedTarget() && yDestination == yTarget)
            {
                return true ;
            }

            return false;
        }
    }
}
