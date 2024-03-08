using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _itemParent;
    [SerializeField]
    private TextMeshProUGUI _moneyText;
    [SerializeField]
    private InventoryItemPrefab _inventoryItemPrefab;
    [SerializeField]
    private ItemOptionsPrefab _optionsPrefab;

    private ItemOptionsPrefab _currentOptions;

    public void OpenCloseInventory()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates shop screen with changed inventory, should be run every time shop inventory is changed
    /// </summary>
    /// <param name="inventory"></param>
    public void UpdateInventory(InventoryObject inventory)
    {
        foreach (Transform item in _itemParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory.Items)
        {
            Instantiate(_inventoryItemPrefab, _itemParent).Initialize(item, this);
        }

        _moneyText.text = inventory.Money + "";
    }

    /// <summary>
    /// Instantiates option tabs, ie. Equip, Return and Unequip
    /// </summary>
    /// <param name="slotTs"></param>
    /// <param name="item"></param>
    public void ShowInventoryOptions(RectTransform slotTs, ItemObject item)
    {
        if(_currentOptions != null)
            Destroy(_currentOptions.gameObject);

        _currentOptions = Instantiate(_optionsPrefab, slotTs);
        _currentOptions.Initialize(item);
        _currentOptions.transform.parent = transform;
    }

    private void OnDisable()
    {
        if (_currentOptions != null)
            Destroy(_currentOptions.gameObject);
    }
}
