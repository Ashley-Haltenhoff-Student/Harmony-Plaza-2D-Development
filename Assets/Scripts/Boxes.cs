using HarmonyPlaza;
using Unity.VisualScripting;
using UnityEngine;

public class Boxes : InteractableObject
{
    
    [SerializeField] private GameObject[] stocks = new GameObject[3];
    [SerializeField] private GameObject[] stockPrefabs;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Player player;
    

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
                inventory.AddToInventory(GetStock());
            }
            else
            {
                if (inventory.GetItem() != null)
                {
                    UI.Notify("You can only hold one thing to stock at a time.");
                }
                else
                {
                    UI.Notify("No more stock left");
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
}
