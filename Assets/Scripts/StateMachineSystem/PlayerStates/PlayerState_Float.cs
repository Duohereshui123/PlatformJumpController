using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Float", fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    [SerializeField] VoidEventChannel playerDefeatedEventChannel;

    [SerializeField] float floatingSpeed = 0.5f;
    [SerializeField] Vector3 floatingPositionOffset;
    [SerializeField] Vector3 vfxOffset;
    [SerializeField] ParticleSystem vfx;
    Vector3 floatingPosition;

    public override void Enter()
    {
        base.Enter();

        playerDefeatedEventChannel.BroadCast();
        Transform playerTransform = player.transform;
        Vector3 vfxPosition = playerTransform.position + new Vector3(playerTransform.localScale.x * vfxOffset.x, vfxOffset.y, 0);
        Instantiate(vfx, vfxPosition, Quaternion.identity, playerTransform);

        floatingPosition = player.transform.position + floatingPositionOffset;
    }

    public override void LogicUpdate()
    {
        Transform playerTransform = player.transform;
        if (Vector3.Distance(playerTransform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition, floatingSpeed * Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}
