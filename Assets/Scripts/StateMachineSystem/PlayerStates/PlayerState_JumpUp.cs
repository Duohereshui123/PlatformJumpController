using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        input.HasJumpInputBuffer = false;

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
