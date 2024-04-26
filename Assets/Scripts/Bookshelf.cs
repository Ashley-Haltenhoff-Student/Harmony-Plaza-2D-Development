using UnityEngine;


namespace HarmonyPlaza
{
    public class Bookshelf : InteractableObject
    {
        [SerializeField] private Player player;
        [SerializeField] private Inventory inventory;
        [SerializeField] private Stock stock = null;

        [SerializeField] private string name;

        private void Update()
        {
            if (allowInteraction && Input.GetKeyDown(KeyCode.E))
            {
                if (inventory.HasStock())
                {
                    if (CorrectBookshelf())
                    {
                        print("Book correctly stocked!");
                        inventory.DestroyStock();
                    }
                    else
                    {
                        print("Wrong bookshelf :(");
                    }
                }
            }
        }

        private bool CorrectBookshelf()
        {
            stock = inventory.GetStock();
            if (stock.GetBookshelf() == name)
            {
                return true;
            }
            return false;
        }
    }
}
