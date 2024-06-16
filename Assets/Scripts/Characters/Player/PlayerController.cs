using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerGroundDetector groundDetector;
    PlayerInput input;
    Rigidbody rb;
    [SerializeField] VoidEventChannel levelClearedEventChannel;

    public AudioSource VoicePlayer { get; private set; }
    public bool Victory { get; private set; }
    public bool CanAirjump { get; set; }
    public bool IsGrounded => groundDetector.IsGrounded;
    public bool IsFalling => rb.velocity.y < 0 && !IsGrounded;
    public float MoveSpeed => MathF.Abs(rb.velocity.x);

    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        VoicePlayer = GetComponentInChildren<AudioSource>();
    }
    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }
    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }

    private void OnLevelCleared()
    {
        Victory = true;
    }

    public void OnDefeated()
    {
        input.DisableGamePlayInputs();

        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        rb.detectCollisions = false;//关闭碰撞检测

        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }

    private void Start()
    {
        input.EnableGameplayInputs();
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxesX, 1f, 1f);
        }
        SetVelocityX(speed * input.AxesX);
    }
    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector3(velocityX, rb.velocity.y, rb.velocity.z);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector3(rb.velocity.x, velocityY, rb.velocity.z);
    }

    public void SetUseGravity(bool value)
    {
        rb.useGravity = value;
    }




}
