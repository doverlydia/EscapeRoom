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
        Rigidbody2D rb= collectable.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        collectable.AddComponent<BoxCollider2D>();
    }
}
