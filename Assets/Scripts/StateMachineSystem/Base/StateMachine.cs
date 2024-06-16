using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //当前状态的更新所需要的内容
    IState currentState;

    //字典 键是状态类型type 值是状态
    protected Dictionary<System.Type,IState> stateTable;

    private void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {

        currentState.PhysicsUpdate();
    }

    //当前状态的启动
    protected void SwitchOn(IState newState)//参数传入新的状态
    {
        //把新状态设置成当前状态并启用
        currentState = newState;
        currentState.Enter();
    }

    public void SwitchState(IState newState)//参数传入需要切换的新的状态
    {
        //先退出当前状态
        currentState.Exit();
        //把新状态设置成当前状态并启用
        SwitchOn(newState);
    }

       public void SwitchState(System.Type newStateType)//重载 参数传入需要切换的新的状态的type
    {
        SwitchState(stateTable[newStateType]);
    }
}
