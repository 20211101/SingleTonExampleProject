using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 버튼 클릭을 점수 증가 요청으로 바꾸어 ScoreManager에 전달하는 책임을 가집니다.
/// </summary>
[RequireComponent(typeof(Button))]
public class ScoreClickButton : MonoBehaviour
{
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
        if (ScoreManager.Instance == null)
        {
            Debug.LogWarning("ScoreManager가 씬에 없습니다. ScoreManager 오브젝트를 하나 배치해주세요.");
            return;
        }

        ScoreManager.Instance.AddScore(addAmount);
    }
}
