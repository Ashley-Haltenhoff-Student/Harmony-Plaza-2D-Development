using UnityEngine;
using HarmonyPlaza;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private Tutorial tutorial;

    [SerializeField] private string[] dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorial.StartTutorial(dialogue);
        gameObject.SetActive(false);
    }
}
