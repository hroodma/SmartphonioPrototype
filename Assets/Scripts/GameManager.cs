using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IInputSystem _input;
    [SerializeField] private Player _player;

    private void Start()
    {
        _input = CreateInput();
        _player.SetInput(_input);
    }

    private void Update()
    {
        _input.InputUpdate();
    }

    private IInputSystem CreateInput() => new DesktopInputSystem();
}
