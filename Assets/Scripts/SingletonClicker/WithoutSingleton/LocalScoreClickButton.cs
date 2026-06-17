using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Inspector로 연결된 LocalScoreManager에 버튼 클릭 점수 증가 요청을 전달하는 책임을 가집니다.
/// </summary>
[RequireComponent(typeof(Button))]
public class LocalScoreClickButton : MonoBehaviour
{
    [SerializeField] private LocalScoreManager scoreManager;
    [SerializeField] private int addAmount = 1;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(AddScore);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(AddScore);
    }

    private void AddScore()
    {
        if (scoreManager == null)
        {
            Debug.LogWarning("LocalScoreClickButton에 LocalScoreManager 참조가 연결되지 않았습니다.");
            return;
        }

        scoreManager.AddScore(addAmount);
    }
}
