using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Openning
{
    public class OpeningMechanic : MonoBehaviour
    {
        [SerializeField] private NpcSpawner npcSpawner;

        public NpcSpawner GetNpcSpawner()
        { return npcSpawner; }
    }
}
