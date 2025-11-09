using UnityEngine;
using UnityEngine.InputSystem;
public class Scene6_SlidingBG : MonoBehaviour
{
    public float ScrollSpeed = 1.0f;
    Material myMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Keyboard.current.wKey.isPressed) moveY += 1f;
        if (Keyboard.current.sKey.isPressed) moveY -= 1f;
        if (Keyboard.current.aKey.isPressed) moveX -= 1f;
        if (Keyboard.current.dKey.isPressed) moveX += 1f;

        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        Vector2 currentOffset = myMaterial.mainTextureOffset;
        currentOffset += moveDir * ScrollSpeed * Time.deltaTime;

        myMaterial.mainTextureOffset = currentOffset;
    }
}
