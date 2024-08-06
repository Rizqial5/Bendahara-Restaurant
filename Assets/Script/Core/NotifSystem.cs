using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TestBR.UI;

namespace TestBR.Core
{
    public class NotifSystem : MonoBehaviour
    {
        [SerializeField] GameObject notifPanel;


        [SerializeField] Transform notifPos;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                StartNotif("bisa");
            }
        }
        public void StartNotif(string notifDetails)
        {
            SpawnNotif(notifDetails);
        }

        public void SpawnNotif(string notifText)
        {
            GameObject spawnNotif = Instantiate(notifPanel, notifPos);

            spawnNotif.GetComponent<NotifPanel>().SetText(notifText);

            Destroy(spawnNotif, 1.5f);
        }
    }
}
