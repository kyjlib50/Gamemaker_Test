using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript2_1 : MonoBehaviour
{
    public float Speed2_1 = 1.0f;
    Rigidbody2D rb2_1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2_1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX2_1 = 0f;
        float moveY2_1 = 0f;
        if (Keyboard.current.upArrowKey.isPressed) moveY2_1 += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY2_1 -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX2_1 += 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX2_1 -= 1f;
        Vector2 Movedir2_1 = new Vector2(moveX2_1, moveY2_1).normalized;
        rb2_1.AddForce(Movedir2_1 * Speed2_1);
    }
}
