using UnityEngine;

public class poopmotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D poopcollision)
    {
        if (poopcollision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
