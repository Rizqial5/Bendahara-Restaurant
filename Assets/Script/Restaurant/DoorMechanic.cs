using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Restaurant
{
    public class DoorMechanic : MonoBehaviour
    {
        [SerializeField] private GameObject doorObject;

        private void Update()
        {
            //if(Input.GetKeyDown(KeyCode.J))
            //{
            //    StartDoorOpen();
            //}
        }

        public void StartDoorOpen()
        {
            StartCoroutine(DoorOpen());
        }

        private IEnumerator DoorOpen()
        {
            yield return new WaitForSeconds(0.3f);

            doorObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            doorObject.SetActive(false);
        }
    }
}
