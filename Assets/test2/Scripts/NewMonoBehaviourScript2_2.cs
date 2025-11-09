using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript2_2 : MonoBehaviour
{
    public float Speed2_2 = 1.0f;
    Rigidbody2D rb2_2;


    void Start()
    {
        rb2_2 = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float moveX2_2 = 0f;
        float moveY2_2 = 0f;
        if (Keyboard.current.upArrowKey.isPressed) moveY2_2 += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY2_2 -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX2_2 += 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX2_2 -= 1f;
        Vector2 Movedir2_2 = new Vector2(moveX2_2, moveY2_2).normalized;
        rb2_2.linearVelocity = Movedir2_2 * Speed2_2;
    }
}