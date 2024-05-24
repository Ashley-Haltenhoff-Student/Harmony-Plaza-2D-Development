using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class CashRegister : InteractableObject
    {
        [SerializeField] private StatHandler stats;

        public Customer[] customersInLine = new Customer[10];
        public Vector3[] linePoints = new Vector3[5];

        public int customersHelped;

        private void Update()
        {
            if (allowInteraction && Input.GetKeyDown(KeyCode.E))
            {
                if (customersInLine[0] != null) { CheckOut(); }
                else { UI.PrintDialogue(dialogue); }
            }
        }

        private void CheckOut()
        {
            UI.PrintDialogue("Checking out customer...");
            stats.IncrementCustomersHelped();
            StartCoroutine(customersInLine[0].Leave());
            customersInLine[0] = null;
            customersHelped++;

            for (int i = 0; i < customersInLine.Length - 1; i++)
            {
                customersInLine[i] = customersInLine[i + 1];
                customersInLine[i].SetTarget(linePoints[i]);
                if (i == 0) { customersInLine[i].isFirstInLine = true; }
            }
        }

    }


}

