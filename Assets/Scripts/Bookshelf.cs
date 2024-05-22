using UnityEngine;


namespace HarmonyPlaza
{
    public class Bookshelf : InteractableObject
    {
        [SerializeField] private Player player;
        [SerializeField] private Inventory inventory;
        [SerializeField] private ResultHandler resultHandler;
        [SerializeField] private Stock stock = null;

        [SerializeField] private string bookshelfName;

        private void Update()
        {
            if (allowInteraction && Input.GetKeyDown(KeyCode.E))
            {
                if (inventory.HasStock())
                {
                    if (CorrectBookshelf())
                    {
                        UI.PrintDialogue("Book correctly stocked!");
                        inventory.DestroyStock();
                        UI.SetObjectBoxInactive();
                        resultHandler.IncrementBookStocked();
                    }
                    else
                    {
                        UI.PrintDialogue("Wrong bookshelf :(");
                    }
                }
                else
                {
                    UI.PrintDialogue(dialogue);
                }
            }
        }

        private bool CorrectBookshelf()
        {
            stock = inventory.GetStock();
            if (stock.GetBookshelf() == bookshelfName)
            {
                return true;
            }
            return false;
        }
    }
}
