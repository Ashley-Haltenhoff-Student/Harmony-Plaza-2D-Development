using HarmonyPlaza;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Boxes : InteractableObject
{
    [SerializeField] private Tutorial tutorial;

    [SerializeField] private GameObject[] stocks = new GameObject[3];
    [SerializeField] private GameObject[] stockPrefabs;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Player player;
    [SerializeField] private Text clockTime;
    private GameObject chosenStock;

    private bool startedStocking = false;

    void Start()
    {
        UI = FindAnyObjectByType<UI>();
        inventory = player.GetComponent<Inventory>();
        CreateStock();
    }

    private void Update()
    {
        if (allowInteraction && Input.GetKeyDown(KeyCode.E))
        {
            if (TryGetStock())
            {
                chosenStock = GetStock();
                inventory.AddToInventory(chosenStock);
                Stock chosenStockDetails = chosenStock.GetComponent<Stock>();
                UI.SetStockIcon(chosenStockDetails.GetIcon());
            }
            else
            {
                if (inventory.GetItem() != null)
                {
                    UI.PrintDialogue("You can only hold one thing to stock at a time.");
                }
                else
                {
                    UI.PrintDialogue("No more stock left");
                    print("Stock Completed at " + clockTime.text);
                }
            }
        }
    }

    private void CreateStock()
    {
        for (int i = 0; i < stocks.Length; i++)
        {
            while(stocks[i] == null)
            {
                int rnd = Random.Range(0, stockPrefabs.Length);
                if (stockPrefabs[rnd] == null)
                {
                    continue;
                }
                else
                {
                    stocks[i] = Instantiate(stockPrefabs[rnd]);
                    stockPrefabs[rnd] = null;
                }
            }
        }
    }

    public bool TryGetStock()
    {
        if (inventory.GetItem() == null)
        {
            for (int i = 0; i <= stocks.Length - 1; i++)
            {
                if (stocks[i] != null)
                {
                    if (stocks[i] == stocks[0]) 
                    {
                        startedStocking = true;
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public GameObject GetStock()
    {
        GameObject chosenStock = null;

        for (int i = 0; i < stocks.Length; i++)
        {
            if (stocks[i] != null)
            {
                chosenStock = stocks[i];
                RemoveStock(i);
                return chosenStock;
            }
        }
        return chosenStock;
    }

    public void RemoveStock(int index)
    {
        stocks[index] = null;
    }

    public bool GetStartedStocking() {  return startedStocking; }

    public GameObject[] GetStockArray() { return stocks; }
}
