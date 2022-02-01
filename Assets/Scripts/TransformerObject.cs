using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

[RequireComponent(typeof(BoxCollider2D))]
public class TransformerObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]Inventory inventory;
    [SerializeField]List<CollectableObject> collectObjectsNeeded;
    [SerializeField] GameObject transformTo;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (transformTo != null && CheckIfReady())
        {
            Instantiate(transformTo, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
    bool CheckIfReady()
    {
        foreach (var item in collectObjectsNeeded)
        {
            if (!inventory.collectedObjects.Contains(item))
                return false;
        }
        return true;
    }
}
