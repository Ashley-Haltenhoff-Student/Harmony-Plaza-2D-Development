using System.Collections;
using System.Threading;
using UnityEngine;

namespace HarmonyPlaza { 

    public class InteractableObject : MonoBehaviour
    {

        private bool allowInteraction = false;
        public string[] dialogue;

        private void Update()
        {
            if (allowInteraction && Input.GetKeyDown(KeyCode.E))
            {
                GoThroughDialogue();
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            allowInteraction = true;
            // UI scripting for object's name
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            allowInteraction = false;
            // UI scripting for object's name
        }

        private void GoThroughDialogue()
        {
            foreach (string s in dialogue)
            {
                print(s);
                //StartCoroutine(WaitForKeyPress());
            }
        }

        private IEnumerator WaitForKeyPress()
        {
            while (!Input.GetKeyDown(KeyCode.RightArrow))
            {   
                Thread.Sleep(1000);
                yield return null;
            }
            StopCoroutine(WaitForKeyPress());
        }

    }
}
