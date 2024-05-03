using HarmonyPlaza;
using System.Collections;
using UnityEngine;

namespace HarmonyPlaza 
{ 

    public class Clock : MonoBehaviour
    {
        [SerializeField] private int timeSpeed = 1;
        [SerializeField] private UI UI;

        private int hour = 8;
        private int minute = 0;
        private string timeOfDay = "am";

        private bool isSingleDigit = true;
        private string zero = "0";

        private void Start()
        {          
            StartCoroutine(UpdateClock());
            
        }

        private IEnumerator UpdateClock()
        {
            while (hour <= 8 && timeOfDay != "pm")
            {
                
                if (minute >= 59) { minute = 0; hour++; isSingleDigit = true; } else { minute++; }
                if (minute >= 10) { isSingleDigit = false; }
                if (isSingleDigit) { zero = "0"; } else { zero = "";}
                if (hour == 12) 
                { 
                    if (timeOfDay == "pm") { timeOfDay = "am"; }
                    else if (timeOfDay == "am") { timeOfDay = "pm"; }
                }

                if (minute % 5 == 0) { UI.SetTime($"{hour}:{zero}{minute}{timeOfDay}"); }
                yield return new WaitForSeconds(timeSpeed);
            }
        }
    }
}

