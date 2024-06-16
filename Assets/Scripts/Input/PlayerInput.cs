using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();

    //跳跃输入缓冲时间限制参数
    [SerializeField] float jumpIntputBufferTime = 0.5f;
    WaitForSeconds waitJumpInputBufferTime;

    public bool HasJumpInputBuffer { get; set; }//跳跃输入缓冲
    public float AxesX => axes.x;
    public bool Move => AxesX != 0;

    public bool Jump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        waitJumpInputBufferTime = new WaitForSeconds(jumpIntputBufferTime);
    }

    private void OnEnable()
    {
        playerInputActions.GamePlay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }

    //再画面上debug显示跳跃输入缓冲的操作
    /* private void OnGUI()
    {
        Rect rect = new Rect(200, 200, 200, 200);
        string massage = "has jump input buffer: " + HasJumpInputBuffer;

        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Bold;

        GUI.Label(rect, massage, style);
    } */

    public void EnableGameplayInputs()
    {
        //启用GamePlay输入Map
        playerInputActions.GamePlay.Enable();
        //锁定光标
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DisableGamePlayInputs()
    {
        playerInputActions.GamePlay.Disable();
    }

    public void SetJumpInputBuffer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }


}
