using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Text timeText;

    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(ShowUI);

        clearTimeTextEventChannel.AddListener(SetTimeText);

        nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
    }

    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(ShowUI);

        clearTimeTextEventChannel.RemoveListener(SetTimeText);

        nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        Cursor.lockState = CursorLockMode.None;
    }

    private void SetTimeText(string obj)
    {
        timeText.text = obj;
    }
}
