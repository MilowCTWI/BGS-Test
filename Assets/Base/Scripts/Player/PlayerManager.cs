using UnityEngine;

/// <summary>
/// Serves as singleton to all player behaviour
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerMovementController MovementController;
    public PlayerAnimationController AnimationController;
    public PlayerInteractionController InteractionController;
    public PlayerInventoryController InventoryController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MovementController.Initialize(this);
        AnimationController.Initialize(this);
        InteractionController.Initialize(this);
        InventoryController.Initialize(this);
    }
}
