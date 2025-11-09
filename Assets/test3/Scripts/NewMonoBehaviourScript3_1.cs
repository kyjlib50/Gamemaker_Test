using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript3_1 : MonoBehaviour
{
    public float MoveAcceleration = 10f;
    public float JumpAcceleration = 20f;
    public float MaxJumpPower = 30f;
    public float MaxMovePower = 10f;
    float currentJumpPower = 0f;

    Rigidbody2D rb3_1;
    bool isJumping3_1 = false; // 바닥에 닿아있으면 false
    Vector2 Move3_1;

    void Start()
    {
        rb3_1 = GetComponent<Rigidbody2D>();
        rb3_1.gravityScale = 1.5f;
        isJumping3_1 = false;
    }

    void FixedUpdate()
    {
        Move3_1 = rb3_1.linearVelocity;

        float moveX3_1 = 0f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX3_1 += 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX3_1 -= 1f;

        // 좌우 이동
        Move3_1.x += moveX3_1 * MoveAcceleration * Time.fixedDeltaTime;
        Move3_1.x = Mathf.Clamp(Move3_1.x, -MaxMovePower, MaxMovePower);

        if (!Keyboard.current.rightArrowKey.isPressed && !Keyboard.current.leftArrowKey.isPressed)
        {
            Move3_1.x = Mathf.Lerp(Move3_1.x, 0, 0.05f); // 서서히 멈춤
        }



        // 점프 유지(누르고 있는 동안)
        if (!isJumping3_1 && Keyboard.current.spaceKey.isPressed)
        {
            currentJumpPower += JumpAcceleration * Time.fixedDeltaTime;

            if (currentJumpPower > MaxJumpPower)
            {
                currentJumpPower = MaxJumpPower;
                Debug.Log("상승제한");
                isJumping3_1 = true;
            }

            Move3_1.y = currentJumpPower;
        }


        rb3_1.linearVelocity = Move3_1;
    }
    void OnTriggerEnter2D(Collider2D collision3_1_green) {
        if (collision3_1_green.gameObject.CompareTag("wall"))
        {
            Debug.Log("녹색 벽 충돌");
        }
    }
    void OnCollisionEnter2D(Collision2D collision3_1)
    {
        if (collision3_1.gameObject.CompareTag("Floor"))
        {
            isJumping3_1 = false; // 바닥에 닿으면 점프 가능
        }

        if (collision3_1.gameObject.CompareTag("wall2"))
        {
            Debug.Log("적색 벽 충돌");
        }
    }
}
