using UnityEngine;
using UnityEngine.UI;

public class ClearTimer : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] VoidEventChannel levelStartedEventChannel;
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] VoidEventChannel playerOnDefeatedEventChannel;
    [SerializeField] StringEventChannel clearTimeTextEventChannel;
    float clearTime;
    bool timerStop = true;

    private void OnEnable()
    {
        levelStartedEventChannel.AddListener(LevelStart);
        levelClearedEventChannel.AddListener(LevelClear);
        playerOnDefeatedEventChannel.AddListener(HideUI);
    }

    private void OnDisable()
    {
        levelStartedEventChannel.RemoveListener(LevelStart);
        levelClearedEventChannel.RemoveListener(LevelClear);
        playerOnDefeatedEventChannel.RemoveListener(HideUI);
    }

    private void FixedUpdate()
    {
        if (timerStop) return;
        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    private void LevelStart()
    {
        timerStop = false;
    }

    private void LevelClear()
    {
        HideUI();

        clearTimeTextEventChannel.BroadCast(timeText.text);
    }

    void HideUI()
    {
        timerStop = true;
        GetComponent<Canvas>().enabled = false;
    }
}