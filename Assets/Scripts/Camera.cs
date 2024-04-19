using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    private Vector3 offset = new Vector3(0f, 0f, -8f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 mainEntranceMax = new Vector3(13.7f, 21.5f);
    private Vector3 mainEntranceMin = new Vector3(-14.7f, -3.5f);
    private Vector3 hallwayMax = new Vector3(0, 0);
    private Vector3 hallwayMin = new Vector3(1, 0);

    private void Update()
    {
        
        //if (TestIfCanMove())
        //{
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -12) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, player.speed);
        //}

    }

    private bool TestIfCanMove()
    {
        Vector3 position = player.transform.position;
        if (position.x < mainEntranceMax.x 
            && position.y < mainEntranceMax.y
            && position.x > mainEntranceMin.x
            && position.y > mainEntranceMin.y)
        {
            return true;
        }

        return false;

        //else if (cameraPosition.x < hallwayMax.x
        //    && cameraPosition.y < hallwayMax.y
        //    && cameraPosition.x > hallwayMin.x
        //    && cameraPosition.y > hallwayMin.y)
        //{

        //}
    }

    
}
