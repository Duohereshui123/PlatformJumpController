using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime = 0.2f;
    [SerializeField] ParticleSystem landVFX;
    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(Vector3.zero);

        Instantiate(landVFX, player.transform.position, Quaternion.identity);
    }
    public override void LogicUpdate()
    {
        if (player.Victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }

        if (input.HasJumpInputBuffer || input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        //如果状态持续时间小于硬直时间，则不进行任何动作
        if (StateDuration < stiffTime)
        {
            return;
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
