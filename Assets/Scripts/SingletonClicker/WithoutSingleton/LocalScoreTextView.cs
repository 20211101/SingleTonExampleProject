using TMPro;
using UnityEngine;

/// <summary>
/// Inspector로 연결된 LocalScoreManager의 점수를 TMP 텍스트 UI에 표시하는 책임을 가집니다.
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class LocalScoreTextView : MonoBehaviour
{
    [SerializeField] private LocalScoreManager scoreManager;
    [SerializeField] private string prefix = "Score: ";

    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (scoreManager == null)
        {
            scoreText.text = prefix + "0";
            Debug.LogWarning("LocalScoreTextView에 LocalScoreManager 참조가 연결되지 않았습니다.");
            return;
        }

        scoreManager.ScoreChanged += UpdateScoreText;
        UpdateScoreText(scoreManager.Score);
    }

    private void OnDisable()
    {
        if (scoreManager != null)
        {
            scoreManager.ScoreChanged -= UpdateScoreText;
        }
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = prefix + score;
    }
}
