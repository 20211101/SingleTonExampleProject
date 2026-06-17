using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// UI 버튼 클릭 시 ScoreGameScene1과 ScoreGameScene2 사이의 씬 전환을 책임집니다.
/// </summary>
[RequireComponent(typeof(Button))]
public class SceneSwapButton : MonoBehaviour
{
    [SerializeField] private string firstSceneName = "ScoreGameScene1";
    [SerializeField] private string secondSceneName = "ScoreGameScene2";

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(LoadOtherScene);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(LoadOtherScene);
    }

    private void LoadOtherScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string nextSceneName = currentSceneName == firstSceneName ? secondSceneName : firstSceneName;

        SceneManager.LoadScene(nextSceneName);
    }
}
