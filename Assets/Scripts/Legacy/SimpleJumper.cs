using UnityEngine;

public class SimpleJumper : MonoBehaviour
{
    // 이 편지는 호서대학교 게임소프트웨어학과
    // 20211101 학번이자 마로소프트 24기
    //선배로부터 시작되어.......
    public Rigidbody rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.AddForce(0, 1000, 0);
        Debug.Log("hadsilhfuiosdahlaf");
        //아무 로근
    }
}
