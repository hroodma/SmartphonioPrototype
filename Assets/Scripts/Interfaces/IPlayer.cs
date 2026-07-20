using System;
using UnityEngine;

public interface IPlayer
{
    event Action<int, int> OnHealthChanged;
    event Action<int> OnScoreChanged;
    event Action OnPlayerDied;
    event Action<IPlayer, IInteractable> OnInteracted;

    void SetInput(IInputSystem input);
    void Initialization();

    void TakeDamage(int damage);
    void Heal(int value);
    void AddScore(int score);
    void Boost(BoostType boostType, float multiple, float timeAction);
}
