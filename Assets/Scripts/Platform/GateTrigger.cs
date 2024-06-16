using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] ParticleSystem pickupVFX;
    [SerializeField] VoidEventChannel gateTriggeredEventChannel;

    private void OnTriggerEnter(Collider other)
    {

        gateTriggeredEventChannel.BroadCast();

        SoundEffectsPlayer.AudioSource.PlayOneShot(pickupSFX);
        Instantiate(pickupVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
