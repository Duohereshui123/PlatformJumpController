using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;//玩家状态集合数组
    Animator animator;
    PlayerController player;
    PlayerInput input;
    private void Awake()
    {
        // 设置animator为PlayerStateMachine对象的子对象中的Animator组件
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
        // 创建一个空的stateTable字典
        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator,player,input, this);
            // 将PlayerState类型和对应的IState对象添加到stateTable字典中
            // 用GetType()方法获取PlayerState类型，用stateTable.Add()方法添加到字典中
            stateTable.Add(state.GetType(), state);
        }
    }

    private void Start()
    {
        // 启动默认状态
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
