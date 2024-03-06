using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private PlayerManager _manager;

    private Vector2 _lastInput;

    private bool _idling;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;
    }

    public void SetWalkingAnimation(bool walking, Vector2 direction)
    {
        if (_idling && !walking)
            return;
        else if (!walking)
        {
            if (_lastInput.y < -.1f)
                _animator.Play("PlayerIdleDown");
            else if (_lastInput.y > .1f)
                _animator.Play("PlayerIdleUp");
            else if (_lastInput.x < .1f)
                _animator.Play("PlayerIdleLeft");
            else if (_lastInput.x > -.1f)
                _animator.Play("PlayerIdleRight");

            _idling = true;
            return;
        }

        if (_idling)
            _idling = false;

        if (direction.y < -.1f)
            _animator.Play("PlayerWalkDown");
        else if (direction.y > .1f)
            _animator.Play("PlayerWalkUp");
        else if (direction.x < -.1f)
            _animator.Play("PlayerWalkLeft");
        else if (direction.x > .1f)
            _animator.Play("PlayerWalkRight");

        _lastInput = direction;
    }
}
