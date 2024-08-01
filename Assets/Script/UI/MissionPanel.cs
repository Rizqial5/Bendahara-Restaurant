using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.Mission;
using TMPro;
using UnityEngine.UI;

namespace TestBR.UI
{
    public class MissionPanel : MonoBehaviour
    {
        [SerializeField] GameObject missionPanel;
        [SerializeField] Button missionButton;

        [SerializeField] TextMeshProUGUI missionTitle;
        [SerializeField] TextMeshProUGUI missionProgress;
        [SerializeField] TextMeshProUGUI missionDesc;

        [SerializeField] Transform primarySpawnLocation;
        [SerializeField] Transform optionalSpawnLocation;


        private MissionManager missionManager;
        private List<Button> spawnedButtons;

        private void Awake()
        {
            missionManager = GetComponent<MissionManager>();
        }

        public void ShowPanel()
        {
            if (missionPanel.activeInHierarchy)
            {

                foreach (Button item in spawnedButtons)
                {
                    Destroy(item.gameObject);
                }


                spawnedButtons.Clear();

                missionPanel.SetActive(false);


                return;
            }

            missionPanel.SetActive(true);

            GenerateButtonMission();

        }


        public void GenerateButtonMission()
        {
            List<MissionSO> missionList = missionManager.GetActiveMissions();
            spawnedButtons = new List<Button>();

            foreach (MissionSO item in missionList)
            {
                if(item.GetMissionCategory() == MissionEnum.Primary)
                {
                    Button primarySpawned = Instantiate(missionButton, primarySpawnLocation);

                    primarySpawned.GetComponentInChildren<TextMeshProUGUI>().text = item.GetMissionTitle();

                    primarySpawned.onClick.AddListener(() => { ShowMissionDetails(item.GetMissionTitle(), item.GetMissionProgressDesc(), item.GetMissionDescipriton()); });

                    spawnedButtons.Add(primarySpawned);
                }
                else if(item.GetMissionCategory() == MissionEnum.Optional)
                {
                    Button optionalSpawned = Instantiate(missionButton, optionalSpawnLocation);

                    optionalSpawned.GetComponentInChildren<TextMeshProUGUI>().text = item.GetMissionTitle();

                    optionalSpawned.onClick.AddListener(() => { ShowMissionDetails(item.GetMissionTitle(), item.GetMissionProgressDesc(), item.GetMissionDescipriton()); });

                    spawnedButtons.Add(optionalSpawned);
                }
            }


            
        }

        public void ShowMissionDetails(string missionTitleText,string missionProgressText , string missionDescriptionText)
        {
            missionTitle.text = missionTitleText;
            missionProgress.text = missionProgressText;
            missionDesc.text = missionDescriptionText;
        }

    }
}
