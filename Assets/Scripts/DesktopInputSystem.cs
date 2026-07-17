using System;
using UnityEngine;

public class DesktopInputSystem : IInputSystem
{
    public event Action<Vector3> OnAxis;

    private bool _isLocked;

    public void Unlock() => _isLocked = false;
    public void Lock() => _isLocked = true;

    public void InputUpdate()
    {
        if (_isLocked)
            return;

        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");

        OnAxis?.Invoke(new Vector3(x, 0, z));
    }
}
