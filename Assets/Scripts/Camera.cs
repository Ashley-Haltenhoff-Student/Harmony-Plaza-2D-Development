using UnityEngine;

namespace HarmonyPlaza { 

    public class Camera : MonoBehaviour
    {
        [SerializeField] Player player;

        private Vector3 offset = new Vector3(0f, 0f, -8f);
        private float smoothTime = 0.25f;
        private Vector3 velocity = Vector3.zero;

        private void Update()
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -12) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, player.speed);
        }
    }
}
