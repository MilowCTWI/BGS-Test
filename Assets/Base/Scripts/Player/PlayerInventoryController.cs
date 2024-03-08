using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    [SerializeField]
    private InventoryObject _inventory;
    [SerializeField]
    private Transform _outfitParent, _hatParent;

    private ItemObject _currentOutfit, _currentHat;
    private InventoryObject _currentShop;

    private PlayerManager _manager;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;

        UIManager.Instance.InventoryController.UpdateInventory(_inventory);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            UIManager.Instance.InventoryController.OpenCloseInventory();
    }

    /// <summary>
    /// Purchases item if player has enough money in inventory
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool TryPurchaseItem(ItemObject item)
    {
        if (item.Value > _inventory.Money)
            return false;

        _inventory.AddItem(item);
        _inventory.Money -= item.Value;

        _currentShop.Items.Remove(item);
        _currentShop.Money += item.Value;

        UIManager.Instance.ShopController.UpdateInventory(_currentShop);
        UIManager.Instance.InventoryController.UpdateInventory(_inventory);

        return true;
    }

    /// <summary>
    /// Returns item to store, if it has enough money
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool TryReturnItem(ItemObject item)
    {
        if (_currentShop == null || !_inventory.Items.Contains(item) || _currentShop.Money < item.Value)
            return false;

        _inventory.Items.Remove(item);
        _inventory.Money += item.Value;

        _currentShop.AddItem(item);
        _currentShop.Money -= item.Value;

        UIManager.Instance.InventoryController.UpdateInventory(_inventory);
        UIManager.Instance.ShopController.UpdateInventory(_currentShop);

        CheckIfSoldEquippedItem(item);

        return true;
    }

    /// <summary>
    /// Equips clothing if not already equipped
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool TryEquipItem(ClothingObject item)
    {
        switch (item.ClothingType)
        {
            case ClothingType.Outfit:
                if (_currentOutfit == item)
                    return false;
                UnequipClothing(_outfitParent);

                Instantiate(item.Prefab, _outfitParent);
                _currentOutfit = item;
                break;
            case ClothingType.Hats:
                if (_currentHat == item)
                    return false;
                UnequipClothing(_hatParent);

                Instantiate(item.Prefab, _hatParent);
                _currentHat = item;

                break;
        }

        PlayerManager.Instance.AnimationController.UpdateAnimators();

        return true;
    }

    public void UnequipClothing(ClothingObject item)
    {
        switch (item.ClothingType)
        {
            case ClothingType.Outfit:
                UnequipClothing(_outfitParent, true);
                _currentOutfit = null;
                break;
            case ClothingType.Hats:
                UnequipClothing(_hatParent, true);
                _currentHat = null;
                break;
        }
    }

    /// <summary>
    /// Checks if item is currently worn as outfit or hat
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool CheckIfItemEquipped(ItemObject item)
    {
        if (_currentOutfit == item)
            return true;
        else if (_currentHat == item)
            return true;

        return false;
    }

    public void OpenedShop(InventoryObject shopInventory)
    {
        _currentShop = shopInventory;
    }

    public void ClosedShop()
    {
        _currentShop = null;
    }

    private void UnequipClothing(Transform clothingParent, bool updateAnimators = false)
    {
        if (clothingParent.childCount < 1)
            return;

        Destroy(clothingParent.GetChild(0).gameObject);
        clothingParent.GetChild(0).parent = null;

        if(updateAnimators)
            PlayerManager.Instance.AnimationController.UpdateAnimators();
    }

    /// <summary>
    /// Unequip item if it was sold
    /// </summary>
    /// <param name="item"></param>
    private void CheckIfSoldEquippedItem(ItemObject item)
    {
        if (_currentOutfit == item)
            UnequipClothing(_outfitParent, true);
        else if (_currentHat == item)
            UnequipClothing(_hatParent, true);
    }

    // Reset player inventory, could be done cleaner with storing the inventory in the beggining and then reseting it on app quit
    private void OnApplicationQuit()
    {
        _inventory.Money = 1000;
        _inventory.Items.Clear();
    }
}
