using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace HarmonyPlaza 
{ 

    public class UI : MonoBehaviour
    {
        [SerializeField] private Text notifyText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text dayText;

        [SerializeField] private Image stockImage;
        [SerializeField] private GameObject objectBox;

        [SerializeField] private Text dialogueText;
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private int dialogueWaitTime = 6000;

        public void Notify(string message)
        {
            //notifyText.text = message;
            //for now I'm using dialogue box for notifications


            //string currentPrint = "";
            //foreach (char c in message)
            //{
            //    currentPrint += c;
            //    dialogueText.text = currentPrint;
            //    Thread.Sleep(200);
            //}

            dialogueText.text = message;
        }

        public void SetStockIcon(Image givenImage)
        {
            stockImage = givenImage;
            objectBox.SetActive(true);
            stockImage.enabled = true;
        }

        public void SetStockInactive()
        {
            stockImage.enabled = false;
        }

        public void SetTime(int givenTime)
        {
            timeText.text = givenTime.ToString();
        }

        public void SetDay(string currentDay)
        {
            dayText.text = currentDay;
        }

        public void PrintDialogue(string dialogue)
        {
            dialogueText.text = dialogue;
            dialogueBox.SetActive(true);
        }

    }
}
