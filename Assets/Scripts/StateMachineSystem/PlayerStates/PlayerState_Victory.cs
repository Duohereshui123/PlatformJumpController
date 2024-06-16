using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachines/PlayerState/Victory", fileName = "PlayerState_Victory")]
public class PlayerState_Victory : PlayerState
{
    [SerializeField] AudioClip[] voice;
    public override void Enter()
    {
        base.Enter();

        input.DisableGamePlayInputs();

        player.VoicePlayer.PlayOneShot(voice[Random.Range(0, voice.Length)]);
    }
}
