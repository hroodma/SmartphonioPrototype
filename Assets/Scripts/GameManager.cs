using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IInputSystem _input;
    [SerializeField] private IPlayer _player;
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

        _player = CreatePlayer();
        _player.SetInput(_input);
        _player.OnInteracted += Interact;
        _player.OnPlayerDied += GameOver;
        _player.Initialization();

        _gameUI.InitializeGameUI(_joystick, _input);

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

        _gameUI.ShowHideJoystick(_joystick, _input);
    }

    private void GameOver()
    {
        _gameUI.ShowHideGameOverScreen(_player.IsDied);
    }

    private IPlayer CreatePlayer() => FindFirstObjectByType<Player>();
}
