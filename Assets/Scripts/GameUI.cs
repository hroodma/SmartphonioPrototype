using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _changeInputPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _changeInputPanel.SetActive(!_changeInputPanel.activeSelf);
        }
    }

    public void ShowJoystick(FixedJoystick joystick)
    {
        joystick.gameObject.SetActive(true);
    }

    public void HideJoystick(FixedJoystick joystick)
    {
        joystick.gameObject.SetActive(false);
    }
}
