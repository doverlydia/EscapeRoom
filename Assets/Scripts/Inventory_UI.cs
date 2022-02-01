using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Transform content;
    [SerializeField] GameObject inventoryItemPrefab;
    private void OnEnable()
    {
        inventory.itemAdded.AddListener(AddUI);
    }
    private void OnDisable()
    {
        inventory.itemAdded.RemoveListener(AddUI);
    }

    public void AddUI()
    {
        CollectableObject item = inventory.collectedObjects[inventory.collectedObjects.Count - 1];
        Sprite sprite = item.GetComponent<SpriteRenderer>().sprite;
        GameObject invItem = Instantiate(inventoryItemPrefab, content);

        invItem.GetComponent<Image>().sprite = sprite;
        invItem.GetComponent<Image>().preserveAspect = true;
    }
}
