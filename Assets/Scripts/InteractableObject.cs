using UnityEngine;

namespace HarmonyPlaza { 

    public class InteractableObject : MonoBehaviour
    {
        [SerializeField] protected UI UI;

        protected bool allowInteraction = false;
        public string[] dialogue;


        private void Start()
        {
            UI = FindAnyObjectByType<UI>();
        }

        private void Update()
        {
            if (allowInteraction && Input.GetKeyDown(KeyCode.E))
            {
                UI.PrintDialogue(dialogue);
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

        

    }
}
