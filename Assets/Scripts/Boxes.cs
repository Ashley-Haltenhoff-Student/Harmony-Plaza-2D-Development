using HarmonyPlaza;
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
                print("successfully got try get stock");
            }
            else
            {
                UI.Notify("No more stock left");
            }
        }
    }

    private void CreateStock()
    {
        for (int i = 0; i < stocks.Length; i++)
        {
            int rnd = Random.Range(0, stockPrefabs.Length);
            stocks[i] = Instantiate(stockPrefabs[rnd]);
        }
    }

    public bool TryGetStock()
    {
        for (int i = 0; i <= stocks.Length - 1; i++)
        {
            if (stocks[i] != null)
            {
                return true;
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
