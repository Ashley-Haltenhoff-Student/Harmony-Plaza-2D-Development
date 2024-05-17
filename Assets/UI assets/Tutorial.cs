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

            StartCoroutine(PrintTutorial(dialogue));
        }
    }

    private IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        continueText.SetActive(true);
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
        continueText.SetActive(false);
    }

    private IEnumerator PrintTutorial(string[] dialogue)
    {
        string currentPrint = "";
        foreach (string s in dialogue)
        {
            continueText.SetActive(false);
            foreach (char c in s)
            {
                boxText.text = currentPrint += c;
                yield return new WaitForSeconds(0.08f);
            }
            continueText.SetActive(true);
            yield return WaitForKeyDown(KeyCode.Space);
        }

        continueText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        continueText.SetActive(false);
        animator.SetTrigger("EndTutorial");
        gameObject.SetActive(false);
        player.SetCanMove(true);
        isGoingThroughTutorial = false;
    }
}