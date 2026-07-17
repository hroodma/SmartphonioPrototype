using System;
using UnityEngine;

public interface IPlayer
{
    event Action<int, int> OnHealthChanged;
    event Action OnPlayerDied;

    void SetInput(IInputSystem input);

    void TakeDamage(int damage);
    void Heal(int value);
    //void Boost(Booster booster, int value);
}
