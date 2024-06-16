using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;
    [SerializeField] AudioClip[] voice;
    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;

    private void OnEnable()
    {
        playerDefeatedEventChannel.AddListener(ShowUI);

        retryButton.onClick.AddListener(SceneLoader.ReloadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }

    private void OnDisable()
    {
        playerDefeatedEventChannel.RemoveListener(ShowUI);

        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;

        AudioClip retryVoice = voice[Random.Range(0, voice.Length)];
        SoundEffectsPlayer.AudioSource.PlayOneShot(retryVoice);

        Cursor.lockState = CursorLockMode.None;
    }
}
