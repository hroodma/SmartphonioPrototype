using UnityEngine;

public class SimpleSpeedBooster : MonoBehaviour, IBooster
{
    private BoostType _boostType = BoostType.Speed;
    public BoostType BoostType => _boostType;

    [SerializeField] private float _timeAction = 2f;
    public float TimeAction => _timeAction;

    [SerializeField] float _multipleValue;
    public float MultipleValue => _multipleValue;

    GameObject IInteractable.gameObject => base.gameObject;
}
