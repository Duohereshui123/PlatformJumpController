using UnityEngine;

public class BlackBall : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggerEventChannel;
    [SerializeField] float lifeTime = 7f;

    private void OnEnable()
    {
        gateTriggerEventChannel.AddListener(OnGateTriggered);
    }

    private void OnDisable()
    {
        gateTriggerEventChannel.RemoveListener(OnGateTriggered);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.OnDefeated();
        }
    }

    void OnGateTriggered()
    {
        Destroy(gameObject, lifeTime);
    }
}
