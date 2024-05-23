using HarmonyPlaza;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


namespace HarmonyPlaza 
{ 
    public class ResultHandler : MonoBehaviour
    {
        [SerializeField] private Boxes boxes;
        [SerializeField] private CashRegister register;

        [SerializeField] private GameObject endResultBox;

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

        private void Awake() { DontDestroyOnLoad(this.gameObject); }

        public void EndResult()
        {
            FindBoxesStocked();
            FindCustomersIgnored();
            customersHelped = register.customersHelped;

            endResultBox.SetActive(true);

            StartCoroutine(PrintNum(booksStockedText, booksStocked, "Books Stocked: "));
            StartCoroutine(PrintNum(booksNotStockedText, booksNotStocked, "Books Not Stocked: "));
            StartCoroutine(PrintNum(customersHelpedText, customersHelped, "Customers Helped: "));
            StartCoroutine(PrintNum(customersIgnoredText, customersIgnored, "Customers Ignored: "));

            CalculateGrade();
        }

        private void FindBoxesStocked()
        {
            GameObject[] stock = boxes.GetStockArray();

            foreach (GameObject s in stock)
            {
                if (s != null) { booksNotStocked++; }
                else if (s != null) { booksStocked++; }
            }

        }

        private void FindCustomersIgnored()
        {
            foreach (Customer c in register.customersInLine)
            {
                if (c != null) { customersIgnored++; }
            }
        }

        private void CalculateGrade()
        {
            // add stats together to calculate grade
            // print grade
            // print result
        }

        private IEnumerator PrintNum(Text textBox, int num, string countIdentifier)
        {
            for (int i = 0; i <= num; i++)
            {
                textBox.text = countIdentifier + i.ToString();
                yield return new WaitForSeconds(0.8f);
            }
        }

        public void IncrementBookStocked() { booksStocked++; }
    }

}

