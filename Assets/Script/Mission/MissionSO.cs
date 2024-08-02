using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Mission
{

    [CreateAssetMenu(fileName = "Mission", menuName = "Mission/Mission List", order = 1)]
    public class MissionSO : ScriptableObject
    {

        [SerializeField] private string missionTitle;
        [SerializeField] MissionEnum missionCategory;

        [TextArea(2, 8)]
        [SerializeField] private string missionDescipriton;


        [SerializeField] CheckMissionSO checkMissionSO;

        private string missionProgressDesc;

        

        public MissionEnum GetMissionCategory() { return missionCategory; }
        public string GetMissionDescipriton() { return missionDescipriton; }
        public string GetMissionTitle() { return missionTitle; }
        public string GetMissionProgressDesc() { return missionProgressDesc; }



        public bool CheckMission()
        {
            return checkMissionSO.CheckCompleteMission();
        }

        public void MissionProgress()
        {
            missionProgressDesc = checkMissionSO.MissionProgress();
        }

        public void GetReward()
        {
            checkMissionSO.GetRewardCompleted();
        }

        public void ResetValues()
        {
            checkMissionSO.ResetValues();
        }

        
       
    }

    
}
