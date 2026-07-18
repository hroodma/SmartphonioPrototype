using UnityEngine;

public enum BoostType { Speed }

public interface IBooster : IInteractable
{
    BoostType BoostType { get; }
    float TimeAction { get; }
    float MultipleValue { get; }
}

