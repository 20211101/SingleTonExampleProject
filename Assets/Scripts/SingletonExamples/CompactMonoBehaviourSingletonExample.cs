using UnityEngine;

/// <summary>
/// 필요한 시점에 씬에서 인스턴스를 찾고 중복 인스턴스를 정리하는 압축형 MonoBehaviour 싱글턴 관리를 책임집니다.
/// </summary>
public class CompactMonoBehaviourSingletonExample : MonoBehaviour
{
    private static CompactMonoBehaviourSingletonExample instance;

    public static CompactMonoBehaviourSingletonExample Instance => instance != null
        ? instance
        : instance = FindAnyObjectByType<CompactMonoBehaviourSingletonExample>();

    [SerializeField] private string currentState = "Ready";

    public string CurrentState => currentState;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeState(string nextState)
    {
        currentState = nextState;
        Debug.Log($"State: {currentState}");
    }
}
