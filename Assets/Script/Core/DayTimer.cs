using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TestBR.Core
{
    public class DayTimer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float timeScaleMultiplication;
        [SerializeField] int startTargetHour;
        [SerializeField] TextMeshProUGUI dayCountText;


        private int dayCount = 1;
        private float currentTime = 0f;
        private bool isClosed = false;

        public UnityEvent onHourChanged;
        public UnityEvent onAnHourLeft;
        public UnityEvent onChangeDays;



        public void TimeStart()
        {
            currentTime += Time.deltaTime * timeScaleMultiplication;

            int newHour = Mathf.FloorToInt(currentTime / 3600f) % 24;
            int currentHour = Mathf.FloorToInt((currentTime - Time.deltaTime * timeScaleMultiplication) / 3600f) % 24;

            if (newHour != currentHour)
            {
                currentHour = newHour;
                TimeDisplay();

                onHourChanged.Invoke();



                print("satu jam berlalu");
            }


            if (currentHour == 16)
            {
                onAnHourLeft.Invoke();
            }
            //else if (currentHour == 17)
            //{
            //    isClosed = true;
            //    print("Toko sudah ditutup");
            //}
        }

        public void TimeDisplay()
        {
            int hours = Mathf.FloorToInt(currentTime / 3600f) % 24;
            //int minutes = Mathf.FloorToInt(timerValue / 60f) % 60;
            timerText.text = string.Format("{0:00}" + ":00 ", hours);
            dayCountText.text = dayCount.ToString();
        }


        public void AddDay()
        {
            dayCount++;
            currentTime = 0;

            onChangeDays.Invoke();
        }

        public void SetStartHour(int startTime)
        {
            currentTime = startTime * 3600f;
        }

        public bool SetIsClosed(bool value)
        {
            return isClosed = value;
        }

        public bool GetIsClosed()
        { return isClosed; }

        public void SetOpen()
        { isClosed = false; }
    }
}