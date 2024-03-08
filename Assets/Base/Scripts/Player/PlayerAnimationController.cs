using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator[] _animators;

    private PlayerManager _manager;

    private Vector2 _lastInput;

    private bool _idling;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;

        _animators = GetComponentsInChildren<Animator>();
    }

    /// <summary>
    /// Remove old animators and pick up animators, should be run every time clothing is changed
    /// </summary>
    public void UpdateAnimators()
    {
        _animators = GetComponentsInChildren<Animator>();

        _idling = false;
        SetWalkingAnimation(false, Vector2.down);
    }

    public void SetWalkingAnimation(bool walking, Vector2 direction)
    {
        if (_idling && !walking)
            return;
        else if (!walking)
        {
            if (_lastInput.y < -.1f)
                SetAnimation("PlayerIdleDown");
            else if (_lastInput.y > .1f)
                SetAnimation("PlayerIdleUp");
            else if (_lastInput.x < -.1f)
                SetAnimation("PlayerIdleLeft");
            else if (_lastInput.x > .1f)
                SetAnimation("PlayerIdleRight");

            _idling = true;
            return;
        }

        if (_idling)
            _idling = false;

        if (direction.y < -.1f)
            SetAnimation("PlayerWalkDown");
        else if (direction.y > .1f)
            SetAnimation("PlayerWalkUp");
        else if (direction.x < -.1f)
            SetAnimation("PlayerWalkLeft");
        else if (direction.x > .1f)
            SetAnimation("PlayerWalkRight");

        _lastInput = direction;
    }

    /// <summary>
    /// Sets animation for all child clothing
    /// </summary>
    /// <param name="animName"></param>
    private void SetAnimation(string animName)
    {
        foreach (var animator in _animators)
        {
            animator.Play(animName);
        }
    }
}
