using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText, _priceText;
    [SerializeField]
    private Image _itemImage;

    private ItemObject _item;

    public void Initialize(ItemObject item)
    {
        _item = item;

        _nameText.text = item.Name;
        _priceText.text = item.Value + "";
        _itemImage.sprite = item.Sprite;
    }

    public void ItemClickedHandler()
    {
        PlayerManager.Instance.InventoryController.TryPurchaseItem(_item);
    }
}
