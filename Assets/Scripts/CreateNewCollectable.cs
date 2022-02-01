using UnityEngine;
using UnityEngine.UI;

enum Type
{
    Regular,
    Hidden
}
public class CreateNewCollectable : MonoBehaviour
{
    [SerializeField] Sprite _sprite;
    [SerializeField] string _name = "new collectable";
    [SerializeField] Type _type = Type.Regular;
    [SerializeField] Inventory inventory;
    public void CreateNew()
    {
        GameObject collectable = new GameObject();
        collectable.name = _name;
        collectable.AddComponent<SpriteRenderer>().sprite = _sprite;
        collectable.GetComponent<SpriteRenderer>().sortingLayerName = _type == Type.Regular ? "Default" : "Hidden";
        collectable.AddComponent<CollectableObject>();
        collectable.GetComponent<CollectableObject>().inventory = inventory;
    }
}
