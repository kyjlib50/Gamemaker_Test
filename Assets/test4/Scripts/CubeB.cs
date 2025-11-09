using UnityEngine;
using UnityEngine.InputSystem;

public class CubeB : MonoBehaviour
{
    public float SpeedB = 1f;  // Inspector에서 이동 속도 조절
    public float TimeSpeed = 1.0f;

    void Update()
    {
        float SpeedBdir = 0f;
        if (Keyboard.current.rightArrowKey.isPressed) SpeedBdir = 1f;
        if (Keyboard.current.leftArrowKey.isPressed) SpeedBdir = -1f;

        // DeltaTime 기반 이동
        transform.Translate(Vector3.right * SpeedBdir * SpeedB * Time.deltaTime);

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
