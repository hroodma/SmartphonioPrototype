using UnityEngine;

public interface IHealable : IInteractable
{
    int HealAmount { get; }
}
