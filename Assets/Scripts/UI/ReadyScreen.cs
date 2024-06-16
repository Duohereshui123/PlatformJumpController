using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelStartEventChannel;
    [SerializeField] AudioClip startSFX;

    //动画事件方法
    private void levelStart()
    {
        levelStartEventChannel.BroadCast();
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    void PlayStartVoice()
    {
        SoundEffectsPlayer.AudioSource.PlayOneShot(startSFX);
    }
}
