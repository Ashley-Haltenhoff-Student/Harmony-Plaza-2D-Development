using HarmonyPlaza;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] private string[] dialogue;
    [SerializeField] private UI UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UI.PrintDialogue(dialogue);
    }
}
