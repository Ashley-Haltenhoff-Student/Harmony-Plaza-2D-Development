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
                StartCoroutine(PrintStringSlowly(givenDialogue, false));
            }
            else { print("Already printing dialogue"); }
        }

        public void PrintDialogue(string[] givenDialogue) 
        { 
            if (!isPrintingDialogue)
            {
                isPrintingDialogue = true;
                dialogueBox.SetActive(true);
                print(dialogueBox.activeSelf);

                bool isLastDialogue = false;
                for (int i = 0; i <= givenDialogue.Length - 1; i++)
                {
                    if (i == givenDialogue.Length) { isLastDialogue = true; }
                    StartCoroutine(PrintStringSlowly(givenDialogue[i], isLastDialogue));
                }
                dialogueBox.SetActive(false);
            }
            else { print("Already printing dialogue"); }
        }

        private IEnumerator PrintStringSlowly(string givenDialogue, bool isLastDialogue)
        {
            string currentPrint = "";
            foreach (char c in givenDialogue)
            {
                dialogueText.text = currentPrint += c;
                yield return new WaitForSeconds(charWaitTime);
            }
            isPrintingDialogue = false;
            yield return StartCoroutine(WaitForKeyDown(KeyCode.RightArrow));

            if (isLastDialogue)
            {
                dialogueBox.SetActive(false);
            }
        }

        private IEnumerator WaitForKeyDown(KeyCode keyCode)
        {
            while (!Input.GetKeyDown(keyCode) || isPrintingDialogue)
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

        public void SetTime(string givenTime) { timeText.text = givenTime; }

        public void SetDay(string currentDay) { dayText.text = currentDay; }

    }
}
