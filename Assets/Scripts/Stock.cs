using UnityEngine;
using UnityEngine.UI;

namespace HarmonyPlaza 
{ 
    public class Stock : MonoBehaviour
    {
        [SerializeField] private string stockName;
        [SerializeField] private string correctBookshelf;
        [SerializeField] private Image icon;

        public string GetBookshelf()
        {
            return correctBookshelf;
        }

        public string GetStockName()
        {
            return stockName;
        }

        public void SetStockName(string givenName)
        {
            stockName = givenName;
        }
    }
}
