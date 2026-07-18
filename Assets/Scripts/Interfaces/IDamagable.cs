using UnityEngine;

public interface IDamagable : IInteractable
{
    int Damage { get; }
}
