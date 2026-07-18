using UnityEngine;

public class SimpleHeal : MonoBehaviour, IHealable
{
    [SerializeField] private int _healAmount;
    public int HealAmount => _healAmount;
    GameObject IInteractable.gameObject => base.gameObject;
}
