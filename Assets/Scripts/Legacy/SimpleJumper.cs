using UnityEngine;

public class SimpleJumper : MonoBehaviour
{
    public Rigidbody rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.AddForce(0, 1000, 0);
        Debug.Log("Hello World!");
        // 헬로 월드 로그 출력했지롱~
    }
}
