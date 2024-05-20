using HarmonyPlaza;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text boxText;
    [SerializeField] private GameObject continueText;

    public bool hasTutorial = true;
    public bool isGoingThroughTutorial;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        animator = GetComponent<Animator>();
    }

    public void StartTutorial(string[] dialogue)
    {
        if (hasTutorial)
        {
            isGoingThroughTutorial = true;
            gameObject.SetActive(true);
            player.SetCanMove(false);

            StartCoroutine(WaitToEndTutorial(KeyCode.Space));
        }
    }

    private IEnumerator WaitToEndTutorial(KeyCode key)
    {
        while (!Input.GetKey(key)) { yield return null; }
        animator.SetTrigger("EndTutorial");
        player.SetCanMove(true);
        isGoingThroughTutorial = false;
    }

    private void SetTutorialInactive() { gameObject.SetActive(false); }
}