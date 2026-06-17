using TMPro;
using UnityEngine;

/// <summary>
/// ScoreManager의 현재 점수를 읽고, 점수 변경 이벤트에 맞춰 TMP 텍스트 UI 갱신을 책임집니다.
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ScoreTextView : MonoBehaviour
{
    [SerializeField] private string prefix = "Score: ";

    private TMP_Text scoreText;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        BindScoreManager();
    }

    private void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.ScoreChanged -= UpdateScoreText;
        }
    }

    private void BindScoreManager()
    {
        scoreManager = ScoreManager.Instance;

        if (scoreManager == null)
        {
            scoreText.text = prefix + "0";
            Debug.LogWarning("ScoreManager가 씬에 없습니다. ScoreManager 오브젝트를 하나 배치해주세요.");
            return;
        }

        scoreManager.ScoreChanged += UpdateScoreText;
        UpdateScoreText(scoreManager.Score);
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = prefix + score;
    }
}
