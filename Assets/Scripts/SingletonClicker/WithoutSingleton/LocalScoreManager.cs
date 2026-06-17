using System;
using UnityEngine;

/// <summary>
/// 싱글턴을 사용하지 않고 현재 씬 안에서만 점수를 저장하고 알리는 책임을 가집니다.
/// </summary>
public class LocalScoreManager : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    [SerializeField] private int score;

    public int Score => score;

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
