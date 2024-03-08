using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOptionsPrefab : MonoBehaviour
{
    [SerializeField]
    private GameObject _equipButton, _returnButton, _unequipButton;

    private ItemObject _selectedItem;

    public void Initialize(ItemObject item)
    {
        _selectedItem = item;

        if (item.Type == ItemType.Clothing)
        {
            if (PlayerManager.Instance.InventoryController.CheckIfItemEquipped(_selectedItem))
                _unequipButton.SetActive(true);
            else
                _equipButton.SetActive(true);
        }

        if (UIManager.Instance.ShopController.CheckIfShopOpen())
            _returnButton.SetActive(true);
    }

    // Runs when corresponding buttons are pressed in inventory

    public void OnEquipButtonPressed()
    {
        switch (_selectedItem.Type)
        {
            case ItemType.Clothing:
                PlayerManager.Instance.InventoryController.TryEquipItem((ClothingObject)_selectedItem);
                break;
        }

        Destroy(gameObject);
    }

    public void OnReturnButtonPressed()
    {
        PlayerManager.Instance.InventoryController.TryReturnItem(_selectedItem);
        Destroy(gameObject);
    }

    public void OnUnequipButtonPressed()
    {
        PlayerManager.Instance.InventoryController.UnequipClothing((ClothingObject) _selectedItem);
        Destroy(gameObject);
    }
}
