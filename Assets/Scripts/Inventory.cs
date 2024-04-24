using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    public void AddToInventory(GameObject item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null) { }
            else
            {
                items[i] = item;
                print(item + "added to inventory at index" + i);
                break;
            }
        }
    }
}
