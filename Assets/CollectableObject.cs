using UnityEngine;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour
{
    public bool collected { get; private set; }
    private void OnMouseDown()
    {
        collected = true;
        gameObject.SetActive(false);
    }
}
