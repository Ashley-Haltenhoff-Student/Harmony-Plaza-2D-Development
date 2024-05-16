using HarmonyPlaza;
using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject canvas;

    public bool hasTutorial = true;

    void Start()
    {
        player = FindFirstObjectByType<Player>();
        animator = GetComponent<Animator>();
    }

    public void StartTutorial()
    {
        if (hasTutorial)
        {
            gameObject.SetActive(true);
            player.SetCanMove(false);

            StartCoroutine(WaitForKeyDown(KeyCode.Space));
        }
    }



    private IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            yield return null;
        }
        animator.SetTrigger("EndTutorial");
        gameObject.SetActive(false);    
        player.SetCanMove(true);
    }
}
