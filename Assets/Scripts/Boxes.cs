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
        inventory = player.GetComponent<Inventory>();
        CreateStock();
    }

    private void Update()
    {
        if (allowInteraction && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddToInventory(GetStock());
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

    public GameObject GetStock()
    {
        int rnd = Random.Range(0, stocks.Length);
        GameObject chosenStock = stocks[rnd];
        RemoveStock(rnd);
        return chosenStock;
    }

    public void RemoveStock(int index)
    {
        stocks[index] = null;
    }
}
