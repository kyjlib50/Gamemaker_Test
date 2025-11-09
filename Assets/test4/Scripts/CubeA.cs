using UnityEngine;
using UnityEngine.InputSystem;

public class CubeA : MonoBehaviour
{
    public float SpeedA = 0.1f;
    public float TimeSpeed = 1.0f;
    void Start()
    {
    }
    void Update()
    {
        float CubeAdir = 0f;

        if (Keyboard.current.rightArrowKey.isPressed) CubeAdir = 1f;
        if (Keyboard.current.leftArrowKey.isPressed) CubeAdir = -1f;

        transform.Translate(Vector3.right * CubeAdir * SpeedA);
        Time.timeScale = TimeSpeed;

        // T키로 슬로우모션 토글
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.2f;
            else
                Time.timeScale = 1.0f;

            TimeSpeed = Time.timeScale; // Inspector 동기화
        }
    }
}

