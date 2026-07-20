using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Player _player;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _healthText;

    private void OnEnable()
    {
        _player.OnInitialized += InitializeUI;
        _player.OnHealthChanged += UpdateHealthUI;
        _player.OnScoreChanged += UpdateScoreUI;
    }

    private void OnDisable()
    {
        _player.OnInitialized -= InitializeUI;
        _player.OnHealthChanged -= UpdateHealthUI;
        _player.OnScoreChanged -= UpdateScoreUI;
    }

    private void InitializeUI(int score, int maxHealth)
    {
        _scoreText.text = $"{score}";
        _healthText.text = $"{maxHealth} / {maxHealth}";
    }
    private void UpdateHealthUI(int currentHealth, int maxHealth) => _healthText.text = $"{currentHealth} / {maxHealth}";
    private void UpdateScoreUI(int score) => _scoreText.text = $"{score}";
}
