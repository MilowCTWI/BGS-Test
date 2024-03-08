using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperController : NPC
{
    [SerializeField]
    private InventoryObject _inventory;

    private InventoryObject _currentInventory;

    private void Awake()
    {
        _currentInventory = new InventoryObject(new List<ItemObject>(_inventory.Items), _inventory.Money);
    }

    public override void OnInteract()
    {
        base.OnInteract();

        UIManager.Instance.ShowShopScreen(_currentInventory);
    }

    public InventoryObject GetInventory()
    {
        return _currentInventory;
    }
}
