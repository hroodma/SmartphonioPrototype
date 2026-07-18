using UnityEngine;

public class SimpleScoreChanger : MonoBehaviour, IScoreChanger
{
    [SerializeField] private int _score = 1;
    public int Score => _score;
    GameObject IInteractable.gameObject  => base.gameObject;
}
