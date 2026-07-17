using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 360f;
    private IInputSystem _input;
    private Vector3 _movement;
    private Quaternion _targetRotation;

    Rigidbody _rb;

    private void Awake()
    {
        //SetInput(new DesktopInputSystem());
        _rb = GetComponent<Rigidbody>();
    }

    public void SetInput(IInputSystem input)
    {
        _input = input;
        input.OnAxis += Move;
    }

    private void Update()
    {
        //_input.InputUpdate();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (_movement.sqrMagnitude < 0.001f)
            return;

        var direction = new Vector3(_movement.x, 0, _movement.z).normalized;

        Vector3 newPosition = _rb.position + direction * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);

        _rb.MoveRotation(Quaternion.RotateTowards(_rb.rotation, _targetRotation, _rotationSpeed * Time.fixedDeltaTime));
    }

    private void Move(Vector3 axis)
    {
        _movement = axis;
        if (_movement.sqrMagnitude > 0.001f)
        {
            _targetRotation = Quaternion.LookRotation(new Vector3(_movement.x, 0, _movement.z));
        }
    }
}
