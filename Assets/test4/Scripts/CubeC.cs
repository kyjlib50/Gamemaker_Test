using UnityEngine;
using UnityEngine.InputSystem;

public class CubeC : MonoBehaviour
{
    public float SpeedC = 10f;  // Inspector에서 이동 속도 조절
    public float TimeSpeed = 1.0f;
    Rigidbody2D CubeCrb;

    void Start()
    {
        CubeCrb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float CubeCdir = 0f;
        if (Keyboard.current.rightArrowKey.isPressed) CubeCdir = 1f;
        if (Keyboard.current.leftArrowKey.isPressed) CubeCdir = -1f;

        // Rigidbody 이동 (DeltaTime 적용)
        CubeCrb.MovePosition(CubeCrb.position + Vector2.right * CubeCdir * SpeedC * Time.fixedDeltaTime);
    }

    void Update()
    {
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
