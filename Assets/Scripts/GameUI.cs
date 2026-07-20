using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _changeInputPanel;
    [SerializeField] private GameObject _gameOverScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _changeInputPanel.SetActive(!_changeInputPanel.activeSelf);
        }
    }

    public void InitializeGameUI(FixedJoystick joystick, IInputSystem input)
    {
        ShowHideJoystick(joystick, input);
        _gameOverScreen.SetActive(false);
    }

    public void ShowHideJoystick(FixedJoystick joystick, IInputSystem input) => joystick.gameObject.SetActive(input is MobileJoystickInputSystem);
    public void ShowHideGameOverScreen(bool turn) => _gameOverScreen.SetActive(turn);
}
