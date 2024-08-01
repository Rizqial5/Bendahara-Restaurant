using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Mission
{

    
    public class CheckMissionSO : ScriptableObject
    {
     
        public virtual bool CheckCompleteMission()
        {
            return false;
        }

        public virtual string MissionProgress()
        {
            return string.Empty;
        }

        public virtual void ResetValues()
        {

        }

    }
}
