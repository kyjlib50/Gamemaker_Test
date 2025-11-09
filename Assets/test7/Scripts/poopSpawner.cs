using UnityEngine;

public class poopSpawner : MonoBehaviour
{
    public GameObject poopPrefab;

    float timeTrigger = 0f;
    float currentCenter = 0f;

    void Update()
    {
        timeTrigger += Time.deltaTime;

        float center = 0f;
        bool check = false;

        if (timeTrigger > 0.5f)
        {
            while (!check)
            {
                // Y 중심 이동량
                center = Random.Range(-0.5f, 0.5f);

                // 이 이동이 범위 안인지 검사
                float newCenter = currentCenter + center;

                if (newCenter >= -4.5f && newCenter <= 4.5f)
                {
                    check = true;            // 조건 통과
                    currentCenter = newCenter;

                    // X 위치는 랜덤
                    float randomX = Random.Range(-7f, 7f);
                    float spawnY = 6f;

                    // 프리팹 생성
                    GameObject poop = Instantiate(poopPrefab);
                    poop.transform.position = new Vector2(randomX, spawnY);

                    timeTrigger = 0f;
                }
            }

            check = false;
        }
    }
}
