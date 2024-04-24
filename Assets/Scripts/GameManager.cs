using UnityEngine;
using UnityEngine.SceneManagement;

namespace HarmonyPlaza { 

    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }
    }
}
