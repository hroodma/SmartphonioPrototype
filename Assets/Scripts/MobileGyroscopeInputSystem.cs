using System;
using UnityEngine;

public class MobileGyroscopeInputSystem : IInputSystem
{
    private bool _isLocked;

    public event Action<Vector3> OnAxis;

    private float _sensitivity = 0.4f;

    public void InputUpdate()
    {
        if (_isLocked)
            return;

        Vector3 acceleration = Input.acceleration;

        float x = Mathf.Clamp(acceleration.x * _sensitivity, -1f, 1f);
        float z = Mathf.Clamp(-acceleration.z * _sensitivity, -1f, 1f);

        OnAxis?.Invoke(new Vector3(x, 0, z));
    }

    public void Lock() => _isLocked = true;

    public void Unlock() => _isLocked = false;
}
