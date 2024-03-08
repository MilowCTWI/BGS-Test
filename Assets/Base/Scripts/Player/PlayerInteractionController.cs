using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private PlayerManager _manager;

    private Interactable _currentInteractable;

    private float _interactionDistance = 3f;
    private bool _openedShop;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (CloseShopOnMove())
            return;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            UIManager.Instance.HideTutorial();

        if (Input.GetKeyDown(KeyCode.E) && _currentInteractable != null)
            Interact();

        if (!_manager.MovementController.GetIsMoving())
            return;

        CheckForInteractables();
    }

    private void CheckForInteractables()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _interactionDistance, 1 << LayerMask.NameToLayer("Interactable"));

        if (hit.collider == null)
        {
            if (_currentInteractable != null)
                _currentInteractable = null;

            return;
        }

        _currentInteractable = hit.collider.GetComponent<Interactable>();
    }

    private void Interact()
    {
        _currentInteractable.OnInteract();
        InteractableType type = _currentInteractable.GetInteractableType();
        switch (type)
        {
            case InteractableType.Shop:
                _openedShop = true;
                _manager.InventoryController.OpenedShop(_currentInteractable.GetComponent<ShopKeeperController>().GetInventory());
                break;
            default:
                break;
        }
    }

    private bool CloseShopOnMove()
    {
        if (_openedShop)
        {
            if (_manager.MovementController.GetIsMoving() || Input.GetKeyDown(KeyCode.E))
            {
                UIManager.Instance.CloseShopScreen();
                _manager.InventoryController.ClosedShop();
                _openedShop = false;
            }

            return true;
        }

        return false;
    }
}
