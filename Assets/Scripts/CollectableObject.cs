using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectableObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] internal Inventory inventory;
    [SerializeField] internal SpriteRenderer sr;
    public bool collected => inventory.collectedObjects.Contains(sr.sprite);
    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.AddToInventory(gameObject.GetComponent<SpriteRenderer>().sprite);
        gameObject.SetActive(false);
    }
}
