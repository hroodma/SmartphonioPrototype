using UnityEngine;

public class SimpleTrap : MonoBehaviour, IDamagable
{
    [SerializeField] private int _damage = 1;
    public int Damage => _damage;
    GameObject IInteractable.gameObject => base.gameObject;
}
