using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using UnityEngine;

namespace TestBR.Mission
{

    
    public class CheckMissionSO : ScriptableObject
    {

        [SerializeField] public StatsSO resourceDatabase;

        public CheckMissionSO(StatsSO resourceDatabase)
        {
            this.resourceDatabase = resourceDatabase;
        }

        public virtual bool CheckCompleteMission()
        {
            return false;
        }

        public virtual string MissionProgress()
        {
            return string.Empty;
        }

        public virtual void GetRewardCompleted()
        { }

        public virtual void ResetValues()
        {

        }

    }
}
