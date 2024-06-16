using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 20f;
    public override void Enter()
    {
        base.Enter();//父类写好的交叉淡化动画
        //进入待机模式 开始减速
        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        //如果有移动按键按下 则切换到移动模式
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

         if(!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicsUpdate()
    {
        //因为没有输入，所以方向要读取localScale的x轴
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
