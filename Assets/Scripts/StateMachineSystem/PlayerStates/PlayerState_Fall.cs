using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;
    [SerializeField] float MoveSpeed = 5f;
    public override void LogicUpdate()
    {
        if (player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.Jump)
        {
            if (player.CanAirjump)
            {
                stateMachine.SwitchState(typeof(PlayerState_AirJump));

                return;

            }

            input.SetJumpInputBuffer();
        }
    }

    public override void PhysicsUpdate()
    {
        //通过速度曲线来控制下落速度
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
        player.Move(MoveSpeed);
    }
}
