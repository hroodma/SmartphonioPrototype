using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IInputSystem _input;
    [SerializeField] private Player _player;
    [SerializeField] private FixedJoystick _joystick;

    private void Start()
    {
        _input = CreateInput();
        _player.SetInput(_input);
    }

    private void Update()
    {
        _input.InputUpdate();
    }

    private IInputSystem CreateInput() => new MobileJoystickInputSystem(_joystick);
}
