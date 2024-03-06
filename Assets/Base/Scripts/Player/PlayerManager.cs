using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovementController MovementController;
    public PlayerAnimationController AnimationController;

    private void Awake()
    {
        MovementController.Initialize(this);
        AnimationController.Initialize(this);
    }
}
