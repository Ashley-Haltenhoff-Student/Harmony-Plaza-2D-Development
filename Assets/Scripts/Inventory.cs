using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject item = null;
        [SerializeField] private Stock heldStock = null;

        public void AddToInventory(GameObject itemGiven)
        {
            if (item == null)
            {
                item = itemGiven;
                heldStock = item.GetComponent<Stock>();
                print(item.name + "added to inventory");
            }
            else
            {
                print("there's already an object in your inventory");
            }
        }

        public bool HasStock()
        {
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DestroyStock()
        {
            if (HasStock())
            {
                print(item.name + "is destroyed");
                item = null;
                heldStock = null;
            }
        }

        public Stock GetStock()
        {
            return heldStock;
        }
    }
}
