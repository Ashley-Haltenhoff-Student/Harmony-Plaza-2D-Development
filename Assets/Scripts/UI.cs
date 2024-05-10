using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HarmonyPlaza 
{ 
    public class UI : MonoBehaviour
    {
        [SerializeField] protected Player player;

        [SerializeField] protected Text timeText;
        [SerializeField] protected Text dayText;

        [SerializeField] protected Text dialogueText;
        [SerializeField] protected GameObject dialogueBox;
        [SerializeField] protected GameObject dialogueContinueText;

        [SerializeField] protected float charWaitTime = 0.08f;

        [SerializeField] private GameObject inventory;
        [SerializeField] private Image stockImage;
        [SerializeField] private GameObject objectBox;
        [SerializeField] private GameObject endResultBox;
        [SerializeField] private Text endResultText;

        protected bool isPrintingDialogue = false;
        protected bool skipToFullText = false;

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isPrintingDialogue) { skipToFullText = true; }

            if (inventory != null && Input.GetKeyDown(KeyCode.Tab))
            {
                if (inventory.activeSelf == true) 
                { 
                    inventory.SetActive(false);
                    player.SetCanMove(true);
                }
                else 
                { 
                    inventory.SetActive(true); 
                    player.SetCanMove(false);
                }
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

        protected IEnumerator HandleDialogue(string[] dialogues)
        {
            player.SetCanMove(false);
            isPrintingDialogue = true;
            dialogueBox.SetActive(true);

            foreach (string dialogue in dialogues)
            {
                yield return StartCoroutine(PrintStringSlowly(dialogue));
                if (!skipToFullText) 
                {
                    dialogueContinueText.SetActive(true);
                    yield return WaitForKeyDown(KeyCode.Space); 
                }
                skipToFullText = false;
                dialogueContinueText.SetActive(false);
            }

            dialogueBox.SetActive(false);
            isPrintingDialogue = false;
            player.SetCanMove(true);
        }

        protected IEnumerator PrintStringSlowly(string givenDialogue)
        {
            string currentPrint = "";
            foreach (char c in givenDialogue)
            {
                if (skipToFullText)
                {
                    dialogueText.text = givenDialogue;
                    dialogueContinueText.SetActive(true);
                    yield return WaitForKeyDown(KeyCode.Space);
                    dialogueContinueText.SetActive(false);
                    break;
                }
                dialogueText.text = currentPrint += c;
                yield return new WaitForSeconds(charWaitTime);
            }
        }

        protected IEnumerator WaitForKeyDown(KeyCode keyCode)
        {
            while (!Input.GetKeyDown(keyCode))
            {
                yield return null;
            }
        }

        public void SetStockIcon(Sprite givenImage)
        {
            stockImage.sprite = givenImage;
            objectBox.SetActive(true);
            
        }

        public void SetObjectBoxInactive() { objectBox.SetActive(false); }
        public void SetTime(string givenTime) { timeText.text = givenTime; }
        public void SetDay(string currentDay) { dayText.text = currentDay; }
        public void EndResult() { endResultBox.SetActive(true); }
        public GameObject GetEndResult() { return endResultBox; }
        public void SetEndResult(string resultText) { endResultText.text = resultText; }
    }
}
