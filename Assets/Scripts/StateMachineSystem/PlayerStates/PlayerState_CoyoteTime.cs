using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float coyoteTime = 0.1f;
    public override void Enter()
    {
        base.Enter();//父类写好的交叉淡化动画
        player.SetUseGravity(false);//进入coyote时间时 取消重力
    }

    public override void Exit()
    {
        player.SetUseGravity(true);
    }

    public override void LogicUpdate()
    {
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if (StateDuration > coyoteTime || !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicsUpdate()
    {
        //物理更新上的移动处理
        player.Move(runSpeed);
    }
}
