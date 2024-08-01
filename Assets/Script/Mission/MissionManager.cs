using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TestBR.Mission
{
    public class MissionManager : MonoBehaviour
    {
        [SerializeField] List<MissionSO> missionDatabase;

        private List<MissionSO> activeMissions;

        private int primaryMissionCount;
        private int optionalMissionCount;

        private Dictionary<MissionSO, bool> missionDatabaseDict;

        


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

                    activeMissions.Add(item.Key);

                    primaryMissionCount++;

                }
                else if (item.Key.GetMissionCategory() == MissionEnum.Optional)
                {
                    if (optionalMissionCount == 3) continue;
                    if (item.Value == true) continue;

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

                    CheckCountMission(item);

                    missionDatabaseDict[item] = true;

                    print(item.GetMissionTitle() + " Telah Selesai");

                    item.ResetValues();

                    //activeMissions.Remove(item);
                    

                }
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

        public void RemoveCompletedMission()
        {
            for (int i = 0; i < activeMissions.Count; i++)
            {
                if (activeMissions[i].CheckMission())
                {
                    activeMissions.RemoveAt(i);
                }
            }
        }

        public List<MissionSO> GetActiveMissions()
        {  return activeMissions; }

        private void OnDisable()
        {
            foreach (var item in missionDatabase)
            {
                item.ResetValues();
            }
        }

    }
}
