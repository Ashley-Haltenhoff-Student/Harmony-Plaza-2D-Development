using UnityEngine;

public class Stock : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private Bookshelf correctBookshelf;

    public Stock(string name, string description, Bookshelf correctBookshelf)
    {
        this.name = name;
        this.description = description;
        this.correctBookshelf = correctBookshelf;
    }

    public void DestoryStock()
    {
        Destroy(gameObject);
    }
}
