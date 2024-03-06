using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 12.5f;

    private PlayerManager _manager;

    private bool _isMoving;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.magnitude < .1f && _isMoving)
            _isMoving = false;
        else if(input.magnitude > .1f && !_isMoving)
            _isMoving = true;

        _manager.AnimationController.SetWalkingAnimation(_isMoving, input);

        if (!_isMoving)
            return;

        input.Normalize();
        transform.Translate(input * _moveSpeed * Time.deltaTime);
    }
}
