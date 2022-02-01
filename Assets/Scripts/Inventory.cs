using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]

public class Inventory : ScriptableObject
{
    [SerializeField] internal List<Sprite> collectedObjects = new List<Sprite>();
    internal UnityEvent itemAdded;

    public void AddToInventory(Sprite item)
    {
        collectedObjects.Add(item);
        itemAdded.Invoke();
    }

    private void OnDisable()
    {
        collectedObjects.Clear();
    }
}
