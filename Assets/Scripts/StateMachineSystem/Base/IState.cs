public interface IState
{
    //进入状态
    void Enter();
    //离开状态
    void Exit();
    //状态逻辑更新
    void LogicUpdate();
    //物理更新
    void PhysicsUpdate();
}
