using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using UnityEngine;

namespace TestBR.NPC
{
    public class NpcAnimController : MonoBehaviour
    {
        private Animator npcAnimator;

        private void Awake()
        {
            npcAnimator = GetComponent<Animator>();
        }

        private void Update()
        {
            


        }

        public void SetAnimWalk(bool isStopped)
        {
            npcAnimator.SetBool("isStopped", isStopped);
        }

        public void SetAnimPos(float XPos, float YPos)
        {
            npcAnimator.SetFloat("XPos", XPos);
            npcAnimator.SetFloat("YPos", YPos);
        }

        
    }
}
