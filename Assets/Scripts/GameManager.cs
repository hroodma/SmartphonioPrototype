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
        _player.OnInteracted += Interact;
    }

    private void Update()
    {
        _input.InputUpdate();
    }

    private void Interact(IPlayer player, IInteractable obj)
    {
        switch (obj)
        {
            case IDamagable damagable:
                player.TakeDamage(damagable.Damage);
                break;

            case IScoreChanger scoreChanger:
                player.AddScore(scoreChanger.Score);
                break;
        }
    }

    //private IInputSystem CreateInput() => new MobileGyroscopeInputSystem();
    private IInputSystem CreateInput() => new MobileJoystickInputSystem(_joystick);
    //private IInputSystem CreateInput() => new DesktopInputSystem();
}
