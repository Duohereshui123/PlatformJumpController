using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField] VoidEventChannel levelClearedEventChannel;


    private void OnTriggerEnter(Collider other)
    {
        levelClearedEventChannel.BroadCast();
        SoundEffectsPlayer.AudioSource.PlayOneShot(pickupSFX);
        Instantiate(pickupVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
