using System;
using UnityEngine;

public interface IPlayer
{
    event Action<int, int> OnHealthChanged;
    event Action OnPlayerDied;
    event Action<IPlayer, IInteractable> OnInteracted;

    void SetInput(IInputSystem input);

    void TakeDamage(int damage);
    void Heal(int value);
    void AddScore(int score);
    void Boost(BoostType boostType, float multiple, float timeAction);
}
