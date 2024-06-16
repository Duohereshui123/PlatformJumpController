using UnityEngine;

//玩家状态 使用课程序化对象 并继承自IState接口
public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;//状态名称字符串
    [SerializeField,Range(0f, 1f)] float transitionDuration = 0.1f;//状态切换的动画持续时间
    float stateStartTime;
    int stateHash;//状态名称字符串转化的哈希值
    protected float currentSpeed;//当前速度
    protected Animator animator;
    protected PlayerController player;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;
    //自制判断当前动画是否完成
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    //当前状态持续时间
    protected float StateDuration => Time.time - stateStartTime;
    private void OnEnable()
    {
        //初始化状态名称字符串的哈希值
        stateHash = Animator.StringToHash(stateName);
    }

    public void Initialize(Animator animator, PlayerController player, PlayerInput input, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.player = player;
        this.input = input;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateName, transitionDuration);
        stateStartTime = Time.time;//记录状态开始时间
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
