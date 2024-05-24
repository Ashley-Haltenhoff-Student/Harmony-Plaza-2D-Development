using HarmonyPlaza;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Boxes boxes;
    [SerializeField] private CashRegister register;

    public int booksStocked;
    public int booksNotStocked;
    public int customersHelped;
    public int customersIgnored;


    private void Awake() { DontDestroyOnLoad(this.gameObject); }


    public void EndGame()
    {
        GameObject[] stock = boxes.GetStockArray();

        foreach (GameObject s in stock)
        {
            if (s != null) { booksNotStocked++; }
        }

        foreach (Customer c in register.customersInLine)
        {
            if (c != null) { customersIgnored++; }
        }

        gameManager.EndGame();
    }

    public void IncrementBookStocked() { booksStocked++; }

    public void IncrementCustomersHelped() { customersHelped++; }

}
