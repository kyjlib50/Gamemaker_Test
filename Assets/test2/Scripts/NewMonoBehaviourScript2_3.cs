using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript2_3 : MonoBehaviour
{
    public float Speed2_3 = 1.0f;
    Rigidbody2D rb2_3;


    void Start()
    {
        rb2_3 = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float moveX2_3 = 0f;
        float moveY2_3 = 0f;
        if (Keyboard.current.upArrowKey.isPressed) moveY2_3 += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY2_3 -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX2_3 += 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX2_3 -= 1f;
        Vector2 Movedir2_3 = new Vector2(moveX2_3, moveY2_3).normalized;
        rb2_3.linearVelocity += Movedir2_3 * Speed2_3 * Time.fixedDeltaTime;
    }
}