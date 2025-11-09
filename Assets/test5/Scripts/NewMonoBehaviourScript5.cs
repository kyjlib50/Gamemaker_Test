using UnityEngine;

public class NewMonoBehaviourScript5 : MonoBehaviour
{
    public float jumpPower5 = 10f;        // 초기 점프 높이
    public float jumpDecay5 = 0.5f;      // 바닥에 닿을 때 점프가 줄어드는 비율
    public float minJump5 = 1f;        // 점프가 거의 0이면 멈춤

    Animator anim5;
    Rigidbody2D circle5;

    void Start()
    {
        anim5 = GetComponent<Animator>();
        circle5 = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision5)
    {
        if (collision5.gameObject.CompareTag("Floor"))
        {
            if (jumpPower5 > minJump5)
            {
                // 점프
                circle5.linearVelocity = new Vector2(circle5.linearVelocity.x, jumpPower5);

                // 점프 높이 줄이기
                jumpPower5 *= jumpDecay5;

                // 애니메이션 활성화
                anim5.Play("jmping5");
            }
        }
    }
}
