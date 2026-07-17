using System;
using UnityEngine;

public interface IInputSystem
{
    event Action<Vector3> OnAxis;

    void Unlock();
    void Lock();

    void InputUpdate();
}
