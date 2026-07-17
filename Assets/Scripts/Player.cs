using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IPlayer
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 360f;

    [SerializeField] private int _maxHealth = 3;
    private int _health;
    public int Health => _health;

    public event Action OnPlayerDied;
    public event Action<int, int> OnHealthChanged;

    private IInputSystem _input;
    private Vector3 _movement;
    private Quaternion _targetRotation;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetInput(IInputSystem input)
    {
        _input = input;
        input.OnAxis += Move;
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

    public void TakeDamage(int damage)
    {
        if (_health > 0)
        {
            _health -= damage;
            OnHealthChanged?.Invoke(_health, _maxHealth);
        }

        if (_health <= 0)
        {
            OnPlayerDied?.Invoke();
        }
    }

    public void Heal(int value)
    {
        if (_health >= _maxHealth)
            return;

        _health += value;
        OnHealthChanged?.Invoke(_health, _maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
