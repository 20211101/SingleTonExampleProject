using System;
using UnityEngine;

/// <summary>
/// 클리커 게임의 현재 점수를 저장하고, 씬이 바뀌어도 유지되는 전역 점수 관리를 책임집니다.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public event Action<int> ScoreChanged;

    [SerializeField] private int score;

    public int Score => score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ScoreChanged?.Invoke(score);
    }

    public void ResetScore()
    {
        score = 0;
        ScoreChanged?.Invoke(score);
    }
}
