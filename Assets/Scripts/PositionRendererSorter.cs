using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] private int sortingOrderBase = 5000;
    [SerializeField] private int offset = 0;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
