using System.Collections;
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

        [SerializeField] private float charWaitTime = 0.08f;

        public bool isPrintingDialogue = false;

        public void PrintDialogue(string givenDialogue) 
        { 
            if (!isPrintingDialogue)
            {
                isPrintingDialogue = true;
                dialogueBox.SetActive(true);
                StartCoroutine(PrintStringSlowly(givenDialogue));
                isPrintingDialogue = false;
            }
            else { print("Already printing dialogue"); }
        }

        public void PrintDialogue(string[] givenDialogue) 
        { 
            if (!isPrintingDialogue)
            {
                isPrintingDialogue = true;
                dialogueBox.SetActive(true);
                StartCoroutine(PrintStringArraySlowly(givenDialogue));
            }
            else { print("Already printing dialogue"); }
        }

        private IEnumerator PrintStringSlowly(string givenDialogue)
        {
            string currentPrint = "";
            foreach (char c in givenDialogue)
            {
                dialogueText.text = currentPrint += c;
                yield return new WaitForSeconds(charWaitTime);
            }
            yield return new WaitForSeconds(3);
            dialogueBox.SetActive(false);
        }

        private IEnumerator PrintStringArraySlowly(string[] givenDialogue)
        {
            foreach (string s in givenDialogue)
            {
                string currentPrint = "";
                foreach (char c in s)
                {
                    dialogueText.text = currentPrint += c;
                    yield return new WaitForSeconds(charWaitTime);
                }
                yield return StartCoroutine(WaitForKeyDown(KeyCode.RightArrow));
            }
            isPrintingDialogue = false;

            yield return new WaitForSeconds(3);
            dialogueBox.SetActive(false);
        }

        private IEnumerator WaitForKeyDown(KeyCode keyCode)
        {
            while (!Input.GetKeyDown(keyCode))
            {
                yield return null;
            }
        }

        public void SetStockIcon(Image givenImage)
        {
            stockImage = givenImage;
            objectBox.SetActive(true);
            stockImage.enabled = true;
        }

        public void SetStockInactive() {  stockImage.enabled = false; }

        public void SetTime(int givenTime) { timeText.text = givenTime.ToString(); }

        public void SetDay(string currentDay) { dayText.text = currentDay; }

    }
}
