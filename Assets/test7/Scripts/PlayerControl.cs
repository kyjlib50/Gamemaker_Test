using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float PlayerMoveAcceleration = 10f;
    public float PlayerJumpAcceleration = 20f;
    public float PlayerMaxJumpPower = 30f;
    public float PlayerMaxMovePower = 10f;
    float PlayercurrentJumpPower = 0f;

    Rigidbody2D Playerrb;
    bool PlayerisJumping = false; // 바닥에 닿아있으면 false
    Vector2 PlayerMove;
    public GameObject GameOvertext;
    public GameObject GameOverVolume;
    Animator playeranimation;

    bool isGameOver = false;

    void Start()
    {
        playeranimation = GetComponent<Animator>();
        Playerrb = GetComponent<Rigidbody2D>();
        Playerrb.gravityScale = 1.5f;
        PlayerisJumping = false;
        GameOvertext.SetActive(false);
        GameOverVolume.SetActive(false);
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            PlayerMove = Playerrb.linearVelocity;

            float moveX3_1 = 0f;
            if (Keyboard.current.rightArrowKey.isPressed) moveX3_1 += 1f;
            if (Keyboard.current.leftArrowKey.isPressed) moveX3_1 -= 1f;

            // 좌우 이동
            PlayerMove.x += moveX3_1 * PlayerMoveAcceleration * Time.fixedDeltaTime;
            PlayerMove.x = Mathf.Clamp(PlayerMove.x, -PlayerMaxMovePower, PlayerMaxMovePower);

            if (!Keyboard.current.rightArrowKey.isPressed && !Keyboard.current.leftArrowKey.isPressed)
            {
                PlayerMove.x = Mathf.Lerp(PlayerMove.x, 0, 0.05f); // 서서히 멈춤
            }



            // 점프 유지(누르고 있는 동안)
            if (!PlayerisJumping && Keyboard.current.spaceKey.isPressed)
            {
                playeranimation.Play("playerjumping");
                PlayercurrentJumpPower += PlayerJumpAcceleration * Time.fixedDeltaTime;

                if (PlayercurrentJumpPower > PlayerMaxJumpPower)
                {
                    PlayercurrentJumpPower = PlayerMaxJumpPower;
                    Debug.Log("상승제한");
                    PlayerisJumping = true;
                }

                PlayerMove.y = PlayercurrentJumpPower;
            }


            Playerrb.linearVelocity = PlayerMove;
        }
    }
    void OnCollisionEnter2D(Collision2D playercollision) {
        if (playercollision.gameObject.CompareTag("Floor")) {
            PlayerisJumping = false;
        }
        if (playercollision.gameObject.CompareTag("poop")) {
            GameOvertext.SetActive(true);
            GameOverVolume.SetActive(true);
            isGameOver = true;
            Time.timeScale = 0f;
        }
    }
}
