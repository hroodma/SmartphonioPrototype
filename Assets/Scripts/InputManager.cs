using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public event Action OnInputSystemChanged;

    [SerializeField] private FixedJoystick _fixedJoystick;

    private IInputSystem _currentInputSystem;
    public IInputSystem CurrentInputSystem => _currentInputSystem;
    public IInputSystem DefaultInputSystem => new MobileJoystickInputSystem(_fixedJoystick);

    public void OnDesktopInputSystemChange() => ChangeInputSystem(new DesktopInputSystem());
    public void OnMobileJoystickInputSystemChange() => ChangeInputSystem(new MobileJoystickInputSystem(_fixedJoystick));
    public void OnMobileGyroscopeInputSystemChange() => ChangeInputSystem(new MobileGyroscopeInputSystem());

    private void ChangeInputSystem(IInputSystem inputSystem)
    {
        _currentInputSystem = inputSystem;
        OnInputSystemChanged?.Invoke();
    }
}
