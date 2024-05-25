using HarmonyPlaza;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace HarmonyPlaza 
{ 
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private StatHandler stats;

        [SerializeField] private Animator transitionAnimator;

        [SerializeField] private Text booksStockedText;
        [SerializeField] private Text booksNotStockedText;
        [SerializeField] private Text customersHelpedText;
        [SerializeField] private Text customersIgnoredText;
        [SerializeField] private Text gradeText;

        [SerializeField] private int booksStocked;
        [SerializeField] private int booksNotStocked;
        [SerializeField] private int customersHelped;
        [SerializeField] private int customersIgnored;
    
        private int totalPoints;
        private string result;

        private int printsFinished = 0;

        private void Start()
        {
            stats = FindFirstObjectByType<StatHandler>();

            booksStocked = stats.booksStocked;
            booksNotStocked = stats.booksNotStocked;
            customersIgnored = stats.customersIgnored;
            customersHelped = stats.customersHelped;

            StartCoroutine(PrintNum(booksStockedText, booksStocked, "Books Stocked: "));
            StartCoroutine(PrintNum(booksNotStockedText, booksNotStocked, "Books Not Stocked: "));
            StartCoroutine(PrintNum(customersHelpedText, customersHelped, "Customers Helped: "));
            StartCoroutine(PrintNum(customersIgnoredText, customersIgnored, "Customers Ignored: "));

            CalculateGrade();
        }

        private void Update()
        {
            if (printsFinished == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    SceneManager.LoadScene("TitleScreen"); 
                }
            }
        }

        private void CalculateGrade()
        {

        }

        private IEnumerator PrintNum(Text textBox, int num, string countIdentifier)
        {
            for (int i = 0; i <= num; i++)
            {
                textBox.text = countIdentifier + i.ToString();
                yield return new WaitForSeconds(0.6f);
            }
            printsFinished++;
        }
    }
}

