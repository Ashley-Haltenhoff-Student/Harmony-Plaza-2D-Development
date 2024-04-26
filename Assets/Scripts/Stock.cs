using UnityEngine;

namespace HarmonyPlaza 
{ 
    public class Stock : MonoBehaviour
    {
        [SerializeField] private string stockName;
        [SerializeField] private string description;
        [SerializeField] private string correctBookshelf;

        private void Start()
        {
            name = gameObject.name;
        }

        public string GetBookshelf()
        {
            return correctBookshelf;
        }
    }
}
