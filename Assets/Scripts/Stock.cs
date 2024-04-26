using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class Stock : MonoBehaviour
    {
        [SerializeField] private string stockName;
        [SerializeField] private string description;
        [SerializeField] private Bookshelf correctBookshelf;

        private void Start()
        {
            name = gameObject.name;
        }

        public void DestroyStock()
        {
            Destroy(gameObject);
        }
    }
}
