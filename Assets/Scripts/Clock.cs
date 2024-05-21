using System.Collections;
using UnityEngine;

namespace HarmonyPlaza 
{ 

    public class Clock : MonoBehaviour
    {
        [SerializeField] private Animator timeAnimator;
        [SerializeField] private Boxes boxes;

        [SerializeField] private float timeSpeed = 1.0f;
        [SerializeField] private UI UI;

        public int hour = 8;
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
            while (!boxes.GetStartedStocking()) { yield return null; }
            while (hour != 5)
            {
                if (minute >= 59) 
                { 
                    minute = 0; 
                    
                    if (hour == 12) { hour = 1; }
                    else { hour++; }
                    
                    isSingleDigit = true; 
                } 
                else { minute++; }

                if (minute >= 10) { isSingleDigit = false; }
                if (isSingleDigit) { zero = "0"; } else { zero = "";}
                if (hour == 12)
                {
                    timeOfDay = "pm";
                    
                }

                if (minute == 0 || minute == 30) { UI.SetTime($"{hour}:{zero}{minute}{timeOfDay}"); }
                yield return new WaitForSeconds(timeSpeed);
            }
            UI.EndResult();
        }

        public int GetHour() { return hour; }
        public int GetMinute() { return minute; }
    }
}

