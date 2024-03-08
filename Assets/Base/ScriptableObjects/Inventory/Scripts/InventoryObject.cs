using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]
public class InventoryObject : ScriptableObject
{
    public List<ItemObject> Items;
    public int Money;

    public void AddItem(ItemObject item)
    {
        Items.Add(item);
    }

    public InventoryObject(List<ItemObject> items, int money)
    {
        Items = items;
        Money = money;
    }
}
