using System;
using UnityEngine;

public class MobileJoystickInputSystem : IInputSystem
{
    private FixedJoystick _joystick;

    private bool _isLocked;

    public event Action<Vector3> OnAxis;

    public MobileJoystickInputSystem(FixedJoystick joystick) => _joystick = joystick;

    public void InputUpdate()
    {
        if (_isLocked)
            return;

        var x = _joystick.Horizontal;
        var z = _joystick.Vertical;

        OnAxis?.Invoke(new Vector3(x, 0, z));
    }

    public void Lock() => _isLocked = true;

    public void Unlock() => _isLocked = false;
}
