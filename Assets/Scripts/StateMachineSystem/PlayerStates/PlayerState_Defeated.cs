using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Defeated", fileName = "PlayerState_Defeated")]
public class PlayerState_Defeated : PlayerState
{
    [SerializeField] ParticleSystem VFX;
    [SerializeField] AudioClip[] voice;

    public override void Enter()
    {
        base.Enter();

        Instantiate(VFX, player.transform.position, Quaternion.identity);

        AudioClip deathVoice = voice[Random.Range(0, voice.Length)];

        player.VoicePlayer.PlayOneShot(deathVoice);
    }

    public override void LogicUpdate()
    {
        if(IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Float));
        }
    }
}
