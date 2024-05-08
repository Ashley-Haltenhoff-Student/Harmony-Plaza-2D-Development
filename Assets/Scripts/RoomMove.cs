using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace HarmonyPlaza { 

    public class RoomMove : MonoBehaviour
    {
        public int sceneBuildIndex;
        public bool canTransition = true;

        [SerializeField] private UI UI;
        [SerializeField] private Player player;
        [SerializeField] private string[] cannotTransitionText;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Player") && canTransition)
            {
                print("Switching Scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
            else if (!canTransition) 
            { 
                UI.PrintDialogue(cannotTransitionText);
            }
        }
    }
}
