using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private RectTransform _shopItemParent;
    [SerializeField]
    private ShopItemPrefab _shopItemPrefab;
    [SerializeField]
    private TextMeshProUGUI _moneyText;

    private InventoryObject _currentInventory;

    public void OpenShop(InventoryObject inventory)
    {
        if (inventory == null)
        {
            Debug.LogError("Shop isn't assigned inventory.");
            return;
        }

        gameObject.SetActive(true);

        foreach (var item in inventory.Items)
        {
            Instantiate(_shopItemPrefab, _shopItemParent).Initialize(item);
        }

        _moneyText.text = inventory.Money + "";
        _currentInventory = inventory;
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);

        foreach (Transform item in _shopItemParent)
        {
            Destroy(item.gameObject);
        }
    }

    public bool CheckIfShopOpen()
    {
        return gameObject.activeInHierarchy;
    }

    public void UpdateInventory(InventoryObject inventory)
    {
        if (inventory == null)
        {
            Debug.LogError("Shop isn't assigned inventory.");
            return;
        }

        foreach (Transform item in _shopItemParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in inventory.Items)
        {
            Instantiate(_shopItemPrefab, _shopItemParent).Initialize(item);
        }

        _moneyText.text = inventory.Money + "";
        _currentInventory = inventory;
    }

    public InventoryObject GetCurrentInventory()
    {
        return _currentInventory;
    }
}
