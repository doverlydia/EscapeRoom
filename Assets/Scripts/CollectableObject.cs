using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectableObject : MonoBehaviour, IPointerClickHandler
{
    public bool collected { get; private set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        collected = true;
        gameObject.SetActive(false);
    }
}
