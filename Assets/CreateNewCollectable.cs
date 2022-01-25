using UnityEngine;
using UnityEngine.UI;

public class CreateNewCollectable : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    [SerializeField] string _name = "new collectable";

    public void CreateNew()
    {
        GameObject collectable = new GameObject();
        collectable.name = _name;
        collectable.AddComponent<SpriteRenderer>().sprite = _sprite;
        collectable.AddComponent<CollectableObject>();
        collectable.AddComponent<BoxCollider2D>();
    }
}
