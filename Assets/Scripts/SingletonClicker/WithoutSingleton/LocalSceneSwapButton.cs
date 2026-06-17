using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 싱글턴 없이 씬을 전환할 때 씬 안 오브젝트들이 새로 생성되는 상황을 보여주는 버튼 동작을 책임집니다.
/// </summary>
[RequireComponent(typeof(Button))]
public class LocalSceneSwapButton : MonoBehaviour
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
