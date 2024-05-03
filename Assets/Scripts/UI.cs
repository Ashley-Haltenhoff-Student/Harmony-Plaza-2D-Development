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
        public bool skipToFullText = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                skipToFullText = true;
            }
        }

        public void PrintDialogue(string givenDialogue)
        {
            if (!isPrintingDialogue)
            {
                StartCoroutine(HandleDialogue(new string[] { givenDialogue }));
            }
            else { Debug.Log("Already printing dialogue"); }
        }

        public void PrintDialogue(string[] givenDialogue)
        {
            if (!isPrintingDialogue)
            {
                StartCoroutine(HandleDialogue(givenDialogue));
            }
            else { Debug.Log("Already printing dialogue"); }
        }

        private IEnumerator HandleDialogue(string[] dialogues)
        {
            isPrintingDialogue = true;
            dialogueBox.SetActive(true);

            foreach (string dialogue in dialogues)
            {
                yield return StartCoroutine(PrintStringSlowly(dialogue));
                if (!skipToFullText) { yield return WaitForKeyDown(KeyCode.Space); }
                skipToFullText = false;
            }

            dialogueBox.SetActive(false);
            isPrintingDialogue = false;
        }

        private IEnumerator PrintStringSlowly(string givenDialogue)
        {
            string currentPrint = "";
            foreach (char c in givenDialogue)
            {
                if (skipToFullText)
                {
                    dialogueText.text = givenDialogue;
                    yield return WaitForKeyDown(KeyCode.Space);
                    break;
                }
                dialogueText.text = currentPrint += c;
                yield return new WaitForSeconds(charWaitTime);
            }
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

        public void SetTime(string givenTime) { timeText.text = givenTime; }

        public void SetDay(string currentDay) { dayText.text = currentDay; }

    }
}
