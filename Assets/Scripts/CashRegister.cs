using HarmonyPlaza;
using UnityEngine;

public class CashRegister : InteractableObject
{
    public Customer[] customersInLine = new Customer[5];
    public Vector3[] linePoints = new Vector3[5];

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
        StartCoroutine(customersInLine[0].Leave());
        customersInLine[0] = null;

        for (int i = 0; i < customersInLine.Length; i++)
        {
            customersInLine[i + 1] = customersInLine[i];
            customersInLine[i].SetTarget(linePoints[i]);
            if (i == 0) { customersInLine[i].isFirstInLine = true; }
        }
    }
}
