using UnityEngine;

public class NewMonoBehaviourScript7 : MonoBehaviour
{
    public float ScrollSpeed = 1.0f;
    Material cloud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloud = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float cloudOffSetX = cloud.mainTextureOffset.x + (ScrollSpeed * Time.deltaTime);


        Vector2 cloudOffSet = new Vector2(cloudOffSetX, 0);

        // 텍스처의 오프셋을 새 값으로 적용 → 텍스처가 좌우로 움직이는 효과 발생
        cloud.mainTextureOffset = cloudOffSet;
    }
}
