using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float Speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Keyboard.current.wKey.isPressed) {            moveY += 1f;}
        if (Keyboard.current.sKey.isPressed) {            moveY -= 1f;}
        if (Keyboard.current.dKey.isPressed) {            moveX += 1f;}
        if (Keyboard.current.aKey.isPressed) {            moveX -= 1f;}
        Vector3 Movedir1 = new Vector3(moveX, moveY, 0.0f).normalized;
        transform.position += Movedir1 * Speed * Time.deltaTime;
    }

}
