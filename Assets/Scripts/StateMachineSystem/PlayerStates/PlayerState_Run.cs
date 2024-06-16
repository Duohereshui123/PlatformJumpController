using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 5f;
    public override void Enter()
    {
        base.Enter();//父类写好的交叉淡化动画

        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        //如果没有按键输入，切换到待机模式
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        //实现加速
        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        if(!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }
    }

    public override void PhysicsUpdate()
    {
        //物理更新上的移动处理
        player.Move(currentSpeed);
    }
}
