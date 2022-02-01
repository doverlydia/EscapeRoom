using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] internal Inventory inventory;
    public bool collected => inventory.collectedObjects.Contains(this);
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.AddToInventory(this);
        gameObject.SetActive(false);
    }
}
