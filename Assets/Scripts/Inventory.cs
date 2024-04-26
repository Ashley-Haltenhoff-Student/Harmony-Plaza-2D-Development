using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject[] items = new GameObject[1];

        public void AddToInventory(GameObject item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    print(item.name + "added to inventory at index" + i);
                    break;
                }
                else
                {
                    print("there's already an object in " + i);
                }
            }
        }
    }
}
