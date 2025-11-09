using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public float Speed1 = 1.0f;
    Rigidbody2D rb1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX1 = 0f;
        float moveY1 = 0f;
        if (Keyboard.current.wKey.isPressed) { moveY1 += 1f; }
        if (Keyboard.current.sKey.isPressed) { moveY1 -= 1f; }
        if (Keyboard.current.dKey.isPressed) { moveX1 += 1f; }
        if (Keyboard.current.aKey.isPressed) { moveX1 -= 1f; }
        Vector2 Movedir2 = new Vector2(moveX1, moveY1).normalized;
        rb1.MovePosition(rb1.position + Movedir2 * Speed1 * Time.fixedDeltaTime);
    }
}
