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
        private Difficulty difficulty;

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
            difficulty = FindFirstObjectByType<Difficulty>();
            stats = FindFirstObjectByType<StatHandler>();

            booksStocked = stats.booksStocked;
            booksNotStocked = stats.booksNotStocked;
            customersIgnored = stats.customersIgnored;
            customersHelped = stats.customersHelped;

            StartCoroutine(PrintNum(booksStockedText, booksStocked, "Books Stocked: "));
            StartCoroutine(PrintNum(booksNotStockedText, booksNotStocked, "Books Not Stocked: "));
            StartCoroutine(PrintNum(customersHelpedText, customersHelped, "Customers Helped: "));
            StartCoroutine(PrintNum(customersIgnoredText, customersIgnored, "Customers Ignored: "));

            gradeText.text = "Grade: " + CalculateGrade();
            Destroy(difficulty);
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

        private char CalculateGrade()
        {
            int points = booksStocked + customersHelped;
            if (difficulty.difficulty == "easy")
            {
                if (points >= 17) { return 'S'; }
                else if (points >= 14) { return 'A'; }
                else if (points >= 12) { return 'B'; }
                else if (points >= 8) { return 'C'; }
                else if (points < 8) { return 'F'; }
            }
            else if (difficulty.difficulty == "hard")
            {
                if (points >= 19) { return 'S'; }
                else if (points >= 17) { return 'A'; }
                else if (points >= 14) { return 'B'; }
                else if (points >= 10) { return 'C'; }
                else if (points < 10) { return 'F'; }
            }
            return 'F';
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

