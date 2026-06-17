using UnityEngine;

/// <summary>
/// MonoBehaviour에 의존하지 않는 가장 기본적인 싱글턴 객체 생성을 책임집니다.
/// </summary>
public sealed class PlainSingletonExample
{
    public static PlainSingletonExample Instance { get; } = new PlainSingletonExample();

    public int Score { get; private set; }

    private PlainSingletonExample()
    {
    }

    public void AddScore(int amount)
    {
        Score += amount;
        Debug.Log($"Score: {Score}");
    }
}
