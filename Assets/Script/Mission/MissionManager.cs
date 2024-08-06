using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TestBR.Core;
using UnityEngine;

namespace TestBR.Mission
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] List<MissionSO> missionDatabase;
        [SerializeField] NotifSystem notifSystem;

        private List<MissionSO> activeMissions;

        private int primaryMissionCount;
        private int optionalMissionCount;

        private Dictionary<MissionSO, bool> missionDatabaseDict;

        private bool isNotifAppear = false;


        public void GenerateMission()
        {
            BuildMissionDictionary();

            foreach (var item in missionDatabaseDict)
            {
                BuildActiveMissions();

                if (item.Key.GetMissionCategory() == MissionEnum.Primary)
                {
                    if (primaryMissionCount == 1) continue;
                    if (item.Value == true)
                    {
                        print("misi ini telah selesai");

                        continue;
                    }
                    if (activeMissions.Contains(item.Key)) continue;

                    activeMissions.Add(item.Key);

                    primaryMissionCount++;

                }
                else if (item.Key.GetMissionCategory() == MissionEnum.Optional)
                {
                    if (optionalMissionCount == 3) continue;
                    if (item.Value == true) continue;
                    if (activeMissions.Contains(item.Key)) continue;

                    activeMissions.Add(item.Key);

                    optionalMissionCount++;
                }
            }
        }

        private void BuildActiveMissions()
        {
            if (activeMissions != null) return;
            

            activeMissions = new List<MissionSO>();
        }

        public void BuildMissionDictionary()
        {
            if (missionDatabaseDict != null) return;

            missionDatabaseDict = new Dictionary<MissionSO, bool>();

            foreach (MissionSO item in missionDatabase)
            {
                missionDatabaseDict[item] = false;
            }
        }


        public void CheckCompleteMission()
        {
            BuildMissionDictionary();

            foreach (MissionSO item in activeMissions)
            {
                item.MissionProgress();

                if(item.CheckMission())
                {
                    if(missionDatabaseDict[item] == true) continue ;

                    missionDatabaseDict[item] = true;

                    if (!isNotifAppear)
                    {
                        notifSystem.StartNotif(item.GetMissionTitle() + " Telah Selesai");

                        isNotifAppear = true;
                    }


                }

                isNotifAppear = false;
            }
        }

        private void CheckCountMission(MissionSO item)
        {
            if (item.GetMissionCategory() == MissionEnum.Primary)
            {
                if (primaryMissionCount == 0) return;
                primaryMissionCount--;
            }
            else if (item.GetMissionCategory() == MissionEnum.Optional)
            {
                if (primaryMissionCount == 0) return;
                optionalMissionCount--;
            }
        }

        public void RemoveCompletedMission(MissionSO mission)
        {
            
             activeMissions.Remove(mission);
            
        }

        public void CompleteButton(MissionSO mission)
        {
            print("Hadiah telah diterima");

            CheckCountMission(mission);

            mission.GetReward();

            RemoveCompletedMission(mission);

            
        }


        public List<MissionSO> GetActiveMissions()
        {  return activeMissions; }

        public Dictionary<MissionSO,bool> GetMissionDatabase()
        { return missionDatabaseDict; }

        private void OnDisable()
        {
            foreach (var item in missionDatabase)
            {
                item.ResetValues();
            }
        }

    }
}
