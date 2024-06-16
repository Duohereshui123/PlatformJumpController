using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/AirJump", fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        player.CanAirjump = false;

        player.VoicePlayer.PlayOneShot(jumpSFX);

        player.SetVelocityY(jumpForce);

        Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFalling)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicsUpdate()
    {
        player.Move(MoveSpeed);
    }
}
