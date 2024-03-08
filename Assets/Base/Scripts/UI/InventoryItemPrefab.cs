using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _nameText;
    [SerializeField]
    private Image _itemImage;

    private InventoryController _controller;
    private ItemObject _item;

    public void Initialize(ItemObject item, InventoryController controller)
    {
        _item = item;
        _controller = controller;

        _nameText.text = item.Name;
        _itemImage.sprite = item.Sprite;
    }

    public void ItemClickedHandler()
    {
        _controller.ShowInventoryOptions(GetComponent<RectTransform>(), _item);
    }
}
