using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;
    [SerializeField]
    private float _moveSpeed = 12.5f;

    private PlayerManager _manager;

    private bool _isMoving;

    public void Initialize(PlayerManager manager)
    {
        _manager = manager;
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Returns if player character is currently moving or not
    /// </summary>
    /// <returns></returns>
    public bool GetIsMoving()
    {
        return _isMoving;
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.magnitude < .1f && _isMoving)
            _isMoving = false;
        else if (input.magnitude > .1f && !_isMoving)
            _isMoving = true;

        _manager.AnimationController.SetWalkingAnimation(_isMoving, input);

        if (!_isMoving)
            return;

        input.Normalize();
        _rb.MovePosition((Vector2)transform.position + input * _moveSpeed * Time.deltaTime);
    }
}
