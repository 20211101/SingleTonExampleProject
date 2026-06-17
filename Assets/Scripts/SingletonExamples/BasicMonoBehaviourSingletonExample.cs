using UnityEngine;

/// <summary>
/// 씬 안에 배치된 MonoBehaviour 인스턴스를 전역에서 접근 가능한 싱글턴으로 관리하는 책임을 가집니다.
/// </summary>
public class BasicMonoBehaviourSingletonExample : MonoBehaviour
{
    public static BasicMonoBehaviourSingletonExample Instance { get; private set; }

    [SerializeField] private int playerGold;

    public int PlayerGold => playerGold;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddGold(int amount)
    {
        playerGold += amount;
        Debug.Log($"Gold: {playerGold}");
    }
}
