using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggeredEventChannel;


    private void OnEnable()
    {
        gateTriggeredEventChannel.AddListener(OpenDoor);
    }

    private void OnDisable()
    {
        gateTriggeredEventChannel.RemoveListener(OpenDoor);
    }
    void OpenDoor()
    {
        Destroy(gameObject);
    }
}
