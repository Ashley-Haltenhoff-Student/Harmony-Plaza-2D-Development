using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject item = null;
        [SerializeField] private Stock heldStock = null;

        [SerializeField] private UI UI;

        private void Start()
        {
            UI = FindAnyObjectByType<UI>();
        }

        public void AddToInventory(GameObject itemGiven)
        {
            
            if (item == null)
            {
                item = itemGiven;
                heldStock = item.GetComponent<Stock>();
                UI.Notify(heldStock.GetStockName() + " added to inventory");
            }
            else
            {
                UI.Notify("there's already an object in your inventory");
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
