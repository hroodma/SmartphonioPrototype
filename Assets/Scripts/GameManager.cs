using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IInputSystem _input;
    [SerializeField] private Player _player;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameUI _gameUI;

    private void Start()
    {
        StartCoroutine(Initialization());
    }

    private void Update()
    {
        _input.InputUpdate();
    }

    private IEnumerator Initialization()
    {
        _inputManager.OnInputSystemChanged += ChangeInputSystem;
        _input = _inputManager.DefaultInputSystem;

        _player.SetInput(_input);
        _player.OnInteracted += Interact;
        _player.Initialization();

        yield break;
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

            case IBooster booster:
                player.Boost(booster.BoostType, booster.MultipleValue, booster.TimeAction);
                break;

            case IHealable healable:
                player.Heal(healable.HealAmount);
                break;
        }
    }

    private void ChangeInputSystem()
    {
        _input = _inputManager.CurrentInputSystem;
        _player.SetInput(_input);

        switch (_input)
        {
            case DesktopInputSystem:
                _gameUI.HideJoystick(_joystick);
                break;

            case MobileJoystickInputSystem:
                _gameUI.ShowJoystick(_joystick);
                break;

            case MobileGyroscopeInputSystem:
                _gameUI.HideJoystick(_joystick);
                break;
        }
    }
    //private IInputSystem CreateInput() => new MobileGyroscopeInputSystem();
    //private IInputSystem CreateInput() => new MobileJoystickInputSystem(_joystick);
    //private IInputSystem CreateInput() => new DesktopInputSystem();
}
